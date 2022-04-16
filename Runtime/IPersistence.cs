using UnityEngine;
using UnityEngine.EventSystems;

namespace Tailemetry
{

	//Interface to be implemented by different types of persistence
	public interface IPersistence
	{

		public void Send(TrackerEv ev);

		public void Flush();
	};
};

