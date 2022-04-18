using UnityEngine;
using UnityEditor;
using System.IO;

namespace Tailemetry.Editor
{
	//Configuration window for Unity Editor
	public class TaiLemetryWindow : EditorWindow
	{
		private string _path;

		public string Path
		{
			get { return _path; }
			set { _path = value; }
		}

		[MenuItem("Window/TaiLemetry")]
		public static void ShowWindow(){
			GetWindow<TaiLemetryWindow>("TaiLemetry");
		}

		void OnGUI(){
			GUILayout.Label("Telemetry Configuration.", EditorStyles.boldLabel);

			EditorGUILayout.Space();

			GUILayout.Label("Trace path: "+Path);

			if (GUILayout.Button("Select trace data folder"))
			{
				Path = EditorUtility.SaveFolderPanel("Trace path data folder", "", "") + "/";
			}

			EditorGUILayout.Space();

			if (GUILayout.Button("Apply configuration")){
				StreamWriter sw = new StreamWriter("TaiLemetry.config");
				sw.WriteLine(Path);
				sw.Close();
			}
		}

	};
};

