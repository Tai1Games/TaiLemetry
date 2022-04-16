using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

namespace Tailemetry
{

	public class Tracker
	{
		private static Tracker instance = null;
        
		public static Tracker GetInstance()
		{
			if (instance == null)
				instance = new Tracker();

			return instance;
		}
	};
};

