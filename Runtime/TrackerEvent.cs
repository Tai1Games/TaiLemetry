using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Analytics;
using System;

namespace Tailemetry
{
	public enum EventType{
		StartSession,
		EndSession,
	}

	public class TrackerEvent
	{
		EventType eventType;
		long timeStamp;
		long sessionId;


		public TrackerEvent(EventType type){
			timeStamp = (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds; //timestamp since epoch
			sessionId = AnalyticsSessionInfo.sessionId;
			eventType = type;
		}

		//TODO all user event should implement how they are serialized
		//public abstract string ToJSON();
	};
};

