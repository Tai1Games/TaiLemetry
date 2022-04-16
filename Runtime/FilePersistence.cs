using UnityEngine;
using UnityEngine.EventSystems;

namespace Tailemetry
{

	public class FilePersistence : IPersistence
	{
		ISerializer serializer;

		public FilePersistence(ISerializer serializerFormat){
			serializer = serializerFormat;
		}
		public void Send(TrackerEvent ev){
			//Serialize object with serializer
			
			//serializers.serialize(ev) or whatever

			//Persist it
		}
	};
};

