using UnityEngine;
using UnityEngine.EventSystems;

namespace Tailemetry
{

	//Interface to be implemented by different types of serialization
	public interface ISerializer
	{
		public string Serialize(TrackerEvent ev);

		public string GetFormatExtension();
	};
};

