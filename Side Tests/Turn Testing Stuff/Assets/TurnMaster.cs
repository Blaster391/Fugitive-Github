using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnMaster : MonoBehaviour {

	//This is for calling all of the objects and telling them to take there turns.
	//DESIGN DECISION, SHOULD THE TURN LIST BE SORTED BY SOME SORT OF SPEED ATTRIBUTE?

	public float turnTime;
	public long turnCount;

	List<Turnable> turnableObjects = new List<Turnable>();
	
	void Start () {
		//Kicks off the turns.
		doTurns ();
	}

	public void objectAdd(Turnable t){ //Adds objects so they take turns.
		turnableObjects.Add (t);
	}

	public void objectRemove(Turnable t){//For when a character dies basically.
		turnableObjects.Remove (t);
	}

	void doTurns()	{ //This method makes everything take there turn.
		Debug.Log ("Turn " + turnCount);

		foreach(Turnable t in turnableObjects){
			t.takeTurn();
		}

		turnCount++;
		StartCoroutine ("turnDelay");
	}

	IEnumerator turnDelay(){ //Delay between turns
		yield return new WaitForSeconds (turnTime);
		doTurns ();
	}
}
