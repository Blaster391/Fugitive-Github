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
		closedList.Add (selected);
		
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

		path.Add (closedList [0]);
		bool pathFound = false;
		gridObject startLoc = currentLoc;
		int breaker = 0;
		while (pathFound == false && breaker < 100) {
			breaker++;
			for (int i = (closedList.Count - 1); i >= 0; i--) {

				if (selected.n == closedList [i]  ||selected.s == closedList [i] ||selected.e == closedList [i] ||selected.w == closedList [i]) {
					path.Add (closedList [i]);
					selected = closedList [i];
					Debug.Log (selected.gameObject.name);
					if (closedList [i] == startLoc) {
						Debug.Log ("Hit");
						path.Add (closedList [i]);
						pathFound = true;
					}
					break;
				}
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
