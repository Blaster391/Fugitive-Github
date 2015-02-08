using UnityEngine;
using System.Collections;

public class Player : Unit {

	// Use this for initialization
	void Start () {
		registerTurnMaster ();
		addAction (new Move (this));
		addAction (new Move (this));
	}
}
