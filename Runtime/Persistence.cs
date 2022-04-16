using UnityEngine;
using UnityEngine.EventSystems;

namespace Tailemetry
{

	//Interface to be implemented by different types of persistence
	public interface Persistence
	{
		public void Send(TrackerEvent ev);

		public void Flush();
	};
};

