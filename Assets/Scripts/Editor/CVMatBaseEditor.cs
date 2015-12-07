using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(CvMatBase), true)]
public class CvMatBaseEditor : Editor 
{
	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		if(GUILayout.Button("View Debug Mat"))
		{
			CvImageWindow win = EditorWindow.GetWindow (typeof(CvImageWindow)) as CvImageWindow;
			win.Target = target as CvMatBase;
		}
	}
}
