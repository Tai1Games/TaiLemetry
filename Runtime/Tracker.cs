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
			//load type of persistence with specified formatter
			//could pass type as argument as well and then instantiate it inside persistence itself
			//for now it's only file
			persistence = new FilePersistence(new JsonSerializer());

			//Send session start event
			StartSessionEv startEvent = new StartSessionEv();
		}

		public void End(){
			//Send session end event
			EndSessionEv endEvent = new EndSessionEv();
		}

		public void TrackEvent(TrackerEv ev){
			
		}
	};
};

