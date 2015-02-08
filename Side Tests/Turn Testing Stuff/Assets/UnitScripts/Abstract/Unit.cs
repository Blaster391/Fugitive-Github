using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Unit : MonoBehaviour, Turnable {

	public List<Action> actionQueue = new List<Action>(); //List of actions for the character to perform in order.

	public void registerTurnMaster(){ //Puts the character on the turn queue, should be in constructor?
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

	public void takeTurn(){ //Takes the turn by picking the first action on the list.
		actionQueue [0].doAction ();
	}

	public GameObject getGameObject(){
		return gameObject;
	}
}
