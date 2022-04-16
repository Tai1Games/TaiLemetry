using UnityEngine;
using UnityEngine.EventSystems;

namespace Tailemetry
{

	public class JsonSerializer : ISerializer
	{
		public string Serialize(TrackerEvent ev)
		{
			return JsonUtility.ToJson(ev);
		}
	};
};

