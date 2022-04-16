using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Tailemetry
{

	public class JsonSerializer : ISerializer
	{
		public string Serialize(TrackerEv ev)
		{
			return JsonConvert.SerializeObject(ev);
		}

		public string GetFormatExtension(){
			return ".json";
		}
	};
};

