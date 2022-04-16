using UnityEngine;
using UnityEngine.EventSystems;

namespace Tailemetry
{

	public class JsonSerializer : ISerializer
	{
		public string Serialize(TrackerEv ev)
		{
			return JsonUtility.ToJson(ev);
		}

		public string GetFormatExtension(){
			return ".json";
		}
	};
};

