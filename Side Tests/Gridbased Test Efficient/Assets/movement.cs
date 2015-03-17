using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class movement : MonoBehaviour {

	public gridObject currentLoc;

	public gridObject targetLoc;

	// Use this for initialization
	void Start () {
		setLoc ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.W) && currentLoc.n != null) {
			currentLoc = currentLoc.n;
			setLoc ();
		}
		if (Input.GetKeyDown (KeyCode.D) && currentLoc.e != null) {
			currentLoc = currentLoc.e;
			setLoc ();
		}
		if (Input.GetKeyDown (KeyCode.S) && currentLoc.s != null) {
			currentLoc = currentLoc.s;
			setLoc ();
		}
		if (Input.GetKeyDown (KeyCode.A) && currentLoc.w != null) {
			currentLoc = currentLoc.w;
			setLoc ();
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			StartCoroutine ("walk");
		}
		if (Input.GetMouseButtonDown (0)) {
			pathfind ();
		}
	}

	void setLoc(){
		transform.position = currentLoc.gameObject.transform.position;
	}

	List<gridObject> openList = new List<gridObject>();
	List<gridObject> closedList = new List<gridObject>();
	List<gridObject> path = new List<gridObject>();

	void pathfind(){
		path.Clear ();
		closedList.Clear ();
		openList.Clear ();
		targetLoc = getTarget ();

		if (currentLoc == targetLoc) {
			Debug.Log ("Found path, already finished");
			return;
		}

		gridObject selected = currentLoc;

		int loop = 0;

		openList.Clear ();
		openList.Add (selected);
		
		while ((selected != targetLoc) && loop < 1000) {

			if (selected.n != null && !closedList.Contains (selected.n)) {
				openList.Add (selected.n);
			}
			if (selected.s != null && !closedList.Contains  (selected.s)) {
				openList.Add (selected.s);
			}
			if (selected.e != null && !closedList.Contains (selected.e)) {
				openList.Add (selected.e);
			}
			if (selected.w != null && !closedList.Contains (selected.w)) {
				openList.Add (selected.w);
			}
			gridObject best = openList [0];
			for (int i = 0; i < openList.Count; i++) {
				if (openList [i].distanceFromTarget(targetLoc) < best.distanceFromTarget(targetLoc)) {
					best = openList [i];
				}
			}
			openList.Remove (best);
			closedList.Add (best);

			selected = best;
			loop++;
		}
		path.Clear ();

		closedList.Reverse ();

		Debug.Log (closedList.Capacity);

		path.Add (closedList [0]);
		for (int i = 1; i < closedList.Count; i++) {

			Debug.Log (i);
			if(closedList[i] == targetLoc){
				path.Add (closedList[i]);
				break;
			}

			if(selected.n == closedList[i]){
				path.Add (closedList[i]);
				selected = closedList[i];
				Debug.Log (closedList[i].gameObject.name);
			}
			else if(selected.s == closedList[i]){
				path.Add (closedList[i]);
				selected = closedList[i];
				Debug.Log (closedList[i].gameObject.name);
			}
			else if(selected.e == closedList[i]){
				path.Add (closedList[i]);
				selected = closedList[i];
				Debug.Log (closedList[i].gameObject.name);
			}
			else if(selected.w == closedList[i]){
				path.Add (closedList[i]);
				selected = closedList[i];
				Debug.Log (closedList[i].gameObject.name);
			}
		}

		path.Reverse ();
	}

	IEnumerator walk(){
		int i = 0;
		while (path.Count > i) {
			yield return new WaitForSeconds (1);
			currentLoc = path[i];
			setLoc ();
			i++;
		}
		path.Clear ();
		Debug.Log ("Finished");
	}

	gridObject getTarget(){
		Ray mouseDir = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit;
		Physics.Raycast (mouseDir, out hit);

		if (hit.collider.gameObject.tag == "Nav") {
			return hit.collider.gameObject.GetComponent<gridObject>();
		}
		return currentLoc;
	}

	
}
