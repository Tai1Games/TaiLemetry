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
		[SerializeField]
		private string _eventType;
		public string EventType
		{
			get { return _eventType; }
			set { _eventType = value; }
		}

		[SerializeField]
		private long _timeStamp;
		public long TimeStamp
		{
			get { return _timeStamp; }
			set { _timeStamp = value; }
		}

		[SerializeField]
		private long _sessionId;
		public long SessionId
		{
			get { return _sessionId; }
			set { _sessionId = value; }
		}

		public TrackerEv()
		{
			TimeStamp = (long)(DateTime.Now - new DateTime(1970, 1, 1)).TotalSeconds; //timestamp since epoch
			SessionId = AnalyticsSessionInfo.sessionId;
		}
	};

	//Progression events
	//-------------------------------------------------
	public class ProgressionEv : TrackerEv
	{
		[SerializeField]
		private Dictionary<string, object> _progressionDict;
		public Dictionary<string, object> ProgressionDict
		{
			get { return _progressionDict; }
			set { _progressionDict = value; }
		}

		public ProgressionEv() : base()
		{
			_progressionDict = new Dictionary<string, object>();
		}
	}

	//UI events
	//-------------------------------------------------
	public class UIEv : TrackerEv
	{
		[SerializeField]
		private int _value;
		public int Value
		{
			get { return _value; }
			set { _value = value; }
		}

		public UIEv() : base()
		{

		}
	}
};

