using UnityEngine;
using UnityEngine.EventSystems;

namespace Tailemetry
{

	public class FilePersistence : Persistence
	{
		Serializer serializer;

		public FilePersistence(Serializer serializerFormat){
			serializer = serializerFormat;
		}
		public void Send(TrackerEvent ev){
			//Serialize object with serializer
			
			//serializers.serialize(ev) or whatever

			//Persist it
		}
	};
};

