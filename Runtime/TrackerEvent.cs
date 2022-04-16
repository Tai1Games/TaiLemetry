using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Analytics;
using System;
using System.Collections.Generic;

namespace Tailemetry
{
	public enum EventType{
		StartSession,
		EndSession,
		MonkeySold,
		Screenshot,
		TwitterScroll,
		MailUsed
	}

	//Base event class
	//-------------------------------------------------
	public class TrackerEv
	{
		private EventType _eventType;
		public EventType EventType{
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
	};

	//Derived events
	//-------------------------------------------------

	public class MonkeySoldEv : TrackerEv {
		private List<int> _numArticles; //Each element contains the id of each accesory
		public List<int> NumArticles{
			get { return _numArticles; }
			set { _numArticles = NumArticles; }
		}

		public MonkeySoldEv() : base() {
			EventType = EventType.MonkeySold;
		}
	}

	public class TwitterScrollEv : TrackerEv {
		private float _scrollDelta;

		public float ScrollDelta{
			get { return _scrollDelta; }
			set { _scrollDelta = value; }
		}

		public TwitterScrollEv() : base() {
			EventType = EventType.Screenshot;
		}
	}

	public class MailUsedEv : TrackerEv {

		private bool _opened;
		public bool Opened{
			get { return _opened; }
			set { Opened = _opened; }
		}

		public MailUsedEv() : base() {
			EventType = EventType.EndSession;
		}
	}

	public class StartSessionEv : TrackerEv {

		public StartSessionEv() : base() {
			EventType = EventType.StartSession;
		}
	}

	public class EndSessionEv : TrackerEv {

		public EndSessionEv() : base() {
			EventType = EventType.EndSession;
		}
	}

	public class ScreenshotEv : TrackerEv {
		public ScreenshotEv() : base() {
			EventType = EventType.Screenshot;
		}
	}
};

