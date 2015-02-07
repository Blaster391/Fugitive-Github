using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnMaster : MonoBehaviour {

	public float turnTime;
	public long turnCount;

	List<Turnable> turnableObjects = new List<Turnable>();

	// Use this for initialization
	void Start () {
		doTurns ();
	}

	public void objectAdd(Turnable t){
		turnableObjects.Add (t);
	}

	public void objectRemove(Turnable t){
		turnableObjects.Remove (t);
	}

	void doTurns()	{
		Debug.Log ("Turn " + turnCount);

		foreach(Turnable t in turnableObjects){
			t.takeTurn();
		}

		turnCount++;
		StartCoroutine ("turnDelay");
	}

	IEnumerator turnDelay(){
		yield return new WaitForSeconds (turnTime);
		doTurns ();
	}
}
