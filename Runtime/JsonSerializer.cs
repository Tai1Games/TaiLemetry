using UnityEngine;
using UnityEngine.EventSystems;

namespace Tailemetry
{

	public class JsonSerializer : ISerializer
	{
		static int i = 0;
		public string Serialize(TrackerEvent ev)
		{
			return (i++).ToString();
		}

		public string GetFormatExtension(){
			return ".json";
		}
	};
};

