using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Analytics;
using System;

namespace Tailemetry
{
	[Serializable]
	public enum EventType{
		StartSession,
		EndSession,
	}

	[Serializable]
	public class TrackerEvent
	{
		[SerializeField]
		EventType eventType;
		[SerializeField]
		long timeStamp;
		[SerializeField]
		long sessionId;


		public TrackerEvent(EventType type){
			timeStamp = (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds; //timestamp since epoch
			sessionId = AnalyticsSessionInfo.sessionId;
			eventType = type;
		}
	};
};

