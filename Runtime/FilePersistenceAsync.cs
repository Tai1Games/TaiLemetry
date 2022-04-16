using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Concurrent;
using System.Threading;
using System.IO;

namespace Tailemetry
{

	public class FilePersistenceAsync : IPersistence
	{
		FlushData flushData;
		private struct FlushData
        {
			public ConcurrentQueue<TrackerEvent> queue;
			public ISerializer serializer;
			public string path;
        }
		


		public FilePersistenceAsync(ISerializer serializerFormat, string path){
			flushData = new FlushData();

			flushData.serializer = serializerFormat;
			flushData.queue = new ConcurrentQueue<TrackerEvent>();
			flushData.path = path + serializerFormat.GetFormatExtension();

		}
		public void Send(TrackerEvent ev){
			//Save event in queue
			flushData.queue.Enqueue(ev);
		}

		public void Flush(){
			var flushThread = new Thread(FlushQueue);
			flushThread.Start(flushData);
		}

		private static void FlushQueue(object data){
			FlushData flushData = (FlushData)data;
			StreamWriter sw = new StreamWriter(flushData.path,append:true);
			TrackerEvent ev;
			while(!flushData.queue.IsEmpty){
				flushData.queue.TryDequeue(out ev);
				sw.WriteLine(flushData.serializer.Serialize(ev));
			}
			sw.Close();
		}
	};
};

