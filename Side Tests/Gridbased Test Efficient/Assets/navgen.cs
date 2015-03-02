using UnityEngine;
using UnityEditor;
using System.Collections;

public class navgen : EditorWindow {

	public GameObject navNode;
		

	// Add menu named "My Window" to the Window menu
	[MenuItem ("Tools/Nav Node Generator")]
	static void Init () {
		// Get existing open window or if none, make a new one:
		navgen window = (navgen)EditorWindow.GetWindow (typeof (navgen));
	}
	
	void OnGUI () {

		navNode = EditorGUILayout.ObjectField(navNode, typeof(Object), true) as GameObject;

		if (GUILayout.Button ("DO THE THING", EditorStyles.toolbarButton)) {
			navNode.GetComponent<gridObject>().propagate(0, 0, 0, 0);
		}

		if (GUILayout.Button ("DO THE DEBUG", EditorStyles.toolbarButton)) {
			navNode.GetComponent<gridObject>().debugRays();
		}
	}
}
