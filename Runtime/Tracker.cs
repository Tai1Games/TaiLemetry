using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

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
			//load type of persistence with specified formatter
			//could pass type as argument as well and then instantiate it inside persistence itself
			//for now it's only file
			persistence = new FilePersistenceAsync(new JsonSerializer(),"Async");

			//Send session start event
			TrackEvent(new TrackerEvent(EventType.StartSession)); //should actually be a completable
		}

		public void End(){
			//Send session end event
			TrackEvent(new TrackerEvent(EventType.EndSession));
		}

		public void TrackEvent(TrackerEvent ev){
			persistence.Send(ev);
		}

		public void Save(){
			persistence.Flush();
		}
	};
};

