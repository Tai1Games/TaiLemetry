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
	//Serializable dictionary declaration to be used in the event
	[Serializable]
	public class StringObjectDictionary : SerializableDictionary<string,int>{}


	public class ProgressionEv : TrackerEv
	{
		[SerializeField]
		private StringObjectDictionary _progressionDict;
		public StringObjectDictionary ProgressionDict
		{
			get { return _progressionDict; }
			set { _progressionDict = value; }
		}

		public ProgressionEv() : base()
		{
			_progressionDict = new StringObjectDictionary();
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

