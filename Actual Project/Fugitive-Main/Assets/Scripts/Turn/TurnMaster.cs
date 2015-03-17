using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TurnMaster : MonoBehaviour {

	public bool paused = false; //Pause stops after all the turns have done.
	public bool freeze = false; //Freeze stops a turn being processed until it becomes true again.
	public float turnTime = 1.0f;
	public float waitTime = 0.5f;
	List<ITurnable> turnList = new List<ITurnable>();

	// Use this for initialization
	void Start () {
		StartCoroutine ("doTurns");
	}
	
	// Update is called once per frame
	void FixedUpdate() {
		if (Input.GetKeyDown ("Pause")) {
			if(!paused){
				paused = true;
			}else{
				paused = false;
			}
		}
	}

	IEnumerator doTurns(){
		while(paused == true){
			yield return new WaitForSeconds(waitTime);
		}
		foreach (ITurnable turn in turnList) {
			while(freeze == true){
				yield return new WaitForSeconds(waitTime);
			}
			turn.takeTurn();
		}
		StartCoroutine ("doEffects");
	}

	IEnumerator doEffects(){
		foreach (ITurnable turn in turnList) {
			while(freeze == true){
				yield return new WaitForSeconds(waitTime);
			}
			turn.doEffects ();
		}
		yield return new WaitForSeconds (turnTime);
		StartCoroutine ("doTurns");
	}

	public void registerTurn(ITurnable turnable){
		turnList.Add (turnable);
	}
	public void removeTurn(ITurnable turnable){
		turnList.Remove (turnable);
	}

}
