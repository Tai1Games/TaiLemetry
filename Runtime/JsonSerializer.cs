using UnityEngine;
using UnityEngine.EventSystems;

namespace Tailemetry
{

	public class JsonSerializer : ISerializer
	{
		static int i = 0;
		public string Serialize(TrackerEv ev)
		{
			return (i++).ToString();
		}

		public string GetFormatExtension(){
			return ".json";
		}
	};
};

