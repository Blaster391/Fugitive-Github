using UnityEngine;
using System.Collections;

public class gridObject : MonoBehaviour {

	public int propagatenumber;
	public int x;
	public int y;
	public int z;

	public bool empty;

	public gridObject n;
	public gridObject s;
	public gridObject e;
	public gridObject w;
	
	public void propagate(int num, int pX, int pY, int pZ){

		x = pX;
		y = pY;
		z = pZ;

		gameObject.name = x + " " + y + " " + z;

		if (num < 1000) {
			if ((Physics.Raycast (gameObject.transform.position, Vector3.forward, 1.49f) == false) &&  (Physics.Raycast (gameObject.transform.position + new Vector3(0.49f,0,0), Vector3.forward, 1.49f) == false) &&  (Physics.Raycast (gameObject.transform.position - new Vector3(0.49f,0,0), Vector3.forward, 1.49f) == false)) {
				if (Physics.Raycast (gameObject.transform.position + Vector3.forward, Vector3.down, 1)) {
					GameObject newNode;
					newNode = Instantiate (gameObject, gameObject.transform.position + Vector3.forward, new Quaternion ()) as GameObject;
					newNode.GetComponent<gridObject> ().propagate (num + 1, x, y, z + 1);
				}
			}
			if ((Physics.Raycast (gameObject.transform.position, Vector3.left, 1.49f) == false ) &&  (Physics.Raycast (gameObject.transform.position + new Vector3(0,0,0.49f), Vector3.left, 1.49f) == false) &&  (Physics.Raycast (gameObject.transform.position - new Vector3(0f,0,0.49f), Vector3.left, 1.49f) == false) ) {
				if (Physics.Raycast (gameObject.transform.position + Vector3.left, Vector3.down, 1)) {
					GameObject newNode;
					newNode = Instantiate (gameObject, gameObject.transform.position + Vector3.left, new Quaternion ()) as GameObject;
					newNode.GetComponent<gridObject> ().propagate (num + 1, x - 1, y, z);
				}
			}
			if ((Physics.Raycast (gameObject.transform.position, Vector3.back, 1.49f) == false)  &&  (Physics.Raycast (gameObject.transform.position + new Vector3(0.49f,0,0), Vector3.back, 1.49f) == false)&&  (Physics.Raycast (gameObject.transform.position - new Vector3(0.49f,0,0), Vector3.back, 1.49f) == false) ) {
				if (Physics.Raycast (gameObject.transform.position + Vector3.back, Vector3.down, 1)) {
					GameObject newNode;
					newNode = Instantiate (gameObject, gameObject.transform.position + Vector3.back, new Quaternion ()) as GameObject;	
					newNode.GetComponent<gridObject> ().propagate (num + 1, x, y, z - 1);
				}
			}
			if ((Physics.Raycast (gameObject.transform.position, Vector3.right, 1.49f) == false ) &&  (Physics.Raycast (gameObject.transform.position + new Vector3(0f,0,0.49f), Vector3.right, 1.49f)== false) && ( Physics.Raycast (gameObject.transform.position - new Vector3(0,0,0.49f), Vector3.right, 1.49f) == false)) {
				if (Physics.Raycast (gameObject.transform.position + Vector3.right, Vector3.down, 1)) {
					GameObject newNode;
					newNode = Instantiate (gameObject, gameObject.transform.position + Vector3.right, new Quaternion ()) as GameObject;				
					newNode.GetComponent<gridObject> ().propagate (num + 1, x + 1, y, z);
					}
				}
			}
		connect ();
	}

	void connect(){
		/*
		RaycastHit hitN;
		RaycastHit hitS;
		RaycastHit hitE;
		RaycastHit hitW;

		string derp = hitN.collider.gameObject.name + "']";

		Physics.Raycast (gameObject.transform.position, Vector3.forward, out hitN, 1f);
		if (hitN.collider != null && hitN.collider.gameObject.tag == "Nav") {
				hitN.collider.GetComponent<gridObject>().s = this;
				n = hitN.collider.GetComponent<gridObject>();
		}
		Physics.Raycast (gameObject.transform.position, Vector3.back, out hitS, 1f);
		if (hitS.collider != null && hitS.collider.gameObject.tag == "Nav") {
				hitS.collider.GetComponent<gridObject>().n = this;
				s = hitS.collider.GetComponent<gridObject>();
		}
		Physics.Raycast (gameObject.transform.position, Vector3.left, out hitW, 1f);
		if (hitW.collider != null && hitW.collider.gameObject.tag == "Nav") {
				hitW.collider.GetComponent<gridObject>().e = this;
				w = hitW.collider.GetComponent<gridObject>();
		}
		Physics.Raycast (gameObject.transform.position, Vector3.right, out hitE, 1f);
		if (hitE.collider != null && hitE.collider.gameObject.tag == "Nav") {
				hitE.collider.GetComponent<gridObject>().w = this;
				e = hitE.collider.GetComponent<gridObject>();
		}
	*/

		GameObject node = GameObject.Find (x + " " + y + " " + (z + 1));
		if (node != null) {
			node.GetComponent<gridObject> ().s = this;
			n = node.GetComponent<gridObject> ();
		} else {
			n = null;
		}
		node = GameObject.Find (x + " " + y + " " + (z - 1));
		if (node != null) {
			node.GetComponent<gridObject>().n = this;
			s = node.GetComponent<gridObject>();
		}else {
			s = null;
		}
		node = GameObject.Find ((x - 1) + " " + y + " " + z);
		if (node != null) {
			node.GetComponent<gridObject>().e = this;
			w = node.GetComponent<gridObject>();
		}else {
			w = null;
		}
		node = GameObject.Find ((x + 1) + " " + y + " " + z);
		if (node != null) {
			node.GetComponent<gridObject>().w = this;
			e = node.GetComponent<gridObject>();
		}else {
			e = null;
		}

	}

	public void debugRays(){
		Debug.DrawRay (gameObject.transform.position, Vector3.forward + new Vector3(0,0,0.5f), Color.blue, 10f);
		Debug.DrawRay (gameObject.transform.position + new Vector3(0.49f,0,0), Vector3.forward, Color.blue, 10f);
		Debug.DrawRay (gameObject.transform.position - new Vector3(0.49f,0,0), Vector3.forward, Color.blue, 10f);
	}

	public int distanceFromTarget(gridObject target){
		int dist = 0;
		if (this.x > target.x) {
			dist += this.x - target.x;
		} else {
			dist += target.x - this.x;
		}
		
		if (this.z > target.z) {
			dist += this.z - target.z;
		} else {
			dist += target.z - this.z;
		}
		
		return dist;
		
	}
	// Update is called once per frame
	void Update () {
	
	}
}
