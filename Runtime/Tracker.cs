using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.IO;

namespace Tailemetry
{

	public class Tracker
	{
		private static Tracker instance = null;
		//Persistence object to use
		IPersistence persistence;
        
		public static Tracker GetInstance()
		{
			if (instance == null)
				instance = new Tracker();

			return instance;
		}

		public void Init(){
			string tracePath = "";
			//in case we had a configuration file.
			if (File.Exists("TaiLemetry.config")){
				StreamReader sr = new StreamReader("TaiLemetry.config");
				tracePath = sr.ReadLine();
				sr.Close();
			}

			//load type of persistence with specified formatter
			//could pass type as argument as well and then instantiate it inside persistence itself
			//for now it's only file
			persistence = new FilePersistenceAsync(new JsonSerializer(),tracePath + UnityEngine.Analytics.AnalyticsSessionInfo.sessionId+"_traces");

			//Send session start event
			TrackerEv startEvent = new TrackerEv();
			startEvent.EventType = "START_EVENT";
		}

		public void End(){
			//Send session end event
			TrackerEv startEvent = new TrackerEv();
			startEvent.EventType = "END_EVENT";
		}

		public void TrackEvent(TrackerEv ev){
			persistence.Send(ev);
		}

		public void Save(){
			persistence.Flush();
		}
	};
};

