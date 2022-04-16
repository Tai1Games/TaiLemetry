using UnityEngine;
using UnityEngine.EventSystems;

namespace Tailemetry
{

	//Interface to be implemented by different types of serialization
	public interface Serializer
	{
		public string Serialize(TrackerEv ev);
	};
};

