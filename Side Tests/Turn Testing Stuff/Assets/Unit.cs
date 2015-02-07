using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Unit : MonoBehaviour, Turnable {

	public List<Action> actionQueue = new List<Action>();

	public void registerTurnMaster(){
		GameObject.Find ("MASTER").GetComponent<TurnMaster> ().objectAdd (this);
	}

	public void addAction(Action a){
		actionQueue.Add (a);
	}

	public void finishAction(){
		actionQueue.RemoveAt (0);
	}
	public void cancelAction(Action a){
		actionQueue.Remove (a);
	}

	public void takeTurn(){
		actionQueue [0].doAction ();
	}

	public GameObject getGameObject(){
		return gameObject;
	}
}
