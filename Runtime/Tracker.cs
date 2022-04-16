using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

namespace Tailemetry
{

	public class Tracker
	{
		private static Tracker instance = null;

		//Persistence object to use
		Persistence persistence;
        
		public static Tracker GetInstance()
		{
			if (instance == null)
				instance = new Tracker();

			return instance;
		}

		public void Init(){

		}

		public void End(){
			//Save events to persistence
		}

		public void TrackEvent(TrackerEvent ev){
			
		}
	};
};

