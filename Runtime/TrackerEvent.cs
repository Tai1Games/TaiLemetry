using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Analytics;
using System;
using System.Collections.Generic;

namespace Tailemetry
{
	//Base event class
	//-------------------------------------------------
	public class TrackerEv
	{
		private string _eventType;
		public string EventType{
			get { return _eventType; }
			set { _eventType = value; }
		}

		private long _timeStamp;
		public long TimeStamp{
			get { return _timeStamp; }
			set { _timeStamp = value; }
		}

		private long _sessionId;
		public long SessionId{
			get { return _sessionId; }
			set { _sessionId = value; }
		}

		public TrackerEv(){
			TimeStamp = (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds; //timestamp since epoch
			SessionId = AnalyticsSessionInfo.sessionId;
		}

		//TODO all user event should implement how they are serialized
		//public abstract string ToJSON();
	};

	//Progression events
	//-------------------------------------------------
	public class ProgressionEv : TrackerEv {
		private Dictionary<string, object> _progressionDict;
		public Dictionary<string, object> ProgressionDict{
			get { return _progressionDict; }
			set { _progressionDict = value; }
		}

		public ProgressionEv() : base() {
			_progressionDict = new Dictionary<string, object>();
		}		
	}

	//UI events
	//-------------------------------------------------
	public class UIEv : TrackerEv{
		private int _value;
		public int Value{
			get { return _value; }
			set { _value = value; }
		}

		public UIEv() : base() {

		}
	}
};

