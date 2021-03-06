using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Concurrent;
using System.Threading;
using System.IO;
using System;

namespace Tailemetry
{

	public class FilePersistenceAsync : IPersistence
	{
		FlushData flushData;
		private struct FlushData
		{
			public ConcurrentQueue<TrackerEv> queue;
			public ISerializer serializer;
			public string path;
		}



		public FilePersistenceAsync(ISerializer serializerFormat, string path)
		{
			flushData = new FlushData();

			flushData.serializer = serializerFormat;
			flushData.queue = new ConcurrentQueue<TrackerEv>();
			flushData.path = path + serializerFormat.GetFormatExtension();

		}
		public void Send(TrackerEv ev)
		{
			//Save event in queue
			flushData.queue.Enqueue(ev);
		}

		public void Flush()
		{
			var flushThread = new Thread(FlushQueue);
			flushThread.Start(flushData);
		}

		private static string GetLastChars(string filename, int numChars)
		{
			var fileInfo = new FileInfo(filename);

			using (var stream = File.OpenRead(filename))
			{
				stream.Seek(fileInfo.Length - numChars, SeekOrigin.Begin);
				using (var textReader = new StreamReader(stream))
				{
					return textReader.ReadToEnd();
				}
			}
		}

		private static void DeleteExistingFooter(string path, ISerializer serializer)
        {
			string footer = serializer.GetFooter() + "\r\n";
			int len = footer.Length; //we add
			string eof = GetLastChars(path, footer.Length);
			if(eof.Equals(footer))
            {
				FileStream fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite);
				fs.SetLength(fs.Length - footer.Length);
				fs.Close();
			}
        }

		private static StreamWriter OpenLogFile(string path,ISerializer serializer)
        {
			FileStream fs = null;
			StreamWriter sw = null;

			//Creation of the logfile
            if (!File.Exists(path))
            {
				fs = File.Create(path);
				sw = new StreamWriter(fs);
				sw.WriteLine(serializer.GetHeader());
				
            }
			//Add events to existing file
            else
            {
                try
                {
					DeleteExistingFooter(path, serializer);
					fs = File.Open(path, FileMode.Append, FileAccess.Write, FileShare.None);
					sw = new StreamWriter(fs);

				}
                catch (Exception e)
                {
					Debug.Log(e.Message);
					//File is already in use
					Debug.Log("Logfile en uso");
					sw = null;
                }
            }
			return sw;
        }

		private static void FlushQueue(object data)
		{
			FlushData flushData = (FlushData)data;
			StreamWriter sw = OpenLogFile(flushData.path, flushData.serializer);
			TrackerEv ev;

			//If the file isnt available to write, sw will be null
			if (sw != null)
			{
				//In to avoid starvation, This is the ONLY place that can deque data
				while (!flushData.queue.IsEmpty)
				{
					flushData.queue.TryDequeue(out ev);
					sw.WriteLine($"{flushData.serializer.Serialize(ev)},");
					Debug.Log(flushData.queue.Count);
				}

				sw.WriteLine(flushData.serializer.GetFooter());
				sw.Close();

				Debug.Log("klose");
			}
		}
	};
};

