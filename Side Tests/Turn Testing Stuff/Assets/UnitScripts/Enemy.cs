using UnityEngine;
using System.Collections;

public class Enemy : Unit{

	// Use this for initialization
	void Start () {
		registerTurnMaster ();
		addAction (new Move (this));
		addAction (new Shoot (this, GameObject.Find ("1st Character").GetComponent<Unit>()));
	}
}
