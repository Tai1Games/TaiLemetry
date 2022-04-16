using UnityEngine;
using UnityEngine.EventSystems;

namespace Tailemetry
{

	//Interface to be implemented by different types of serialization
	public interface ISerializer
	{
		public string Serialize(TrackerEv ev);

		public string GetFormatExtension();
	};
};

