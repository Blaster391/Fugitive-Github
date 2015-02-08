using UnityEngine;
using System.Collections;

public interface Turnable {

	//This is the interface for anything that should take turns.

	void takeTurn();
	void registerTurnMaster(); //This should put the object on the list of "Things that take turns"
	void addAction(Action a);
	void finishAction();
	void cancelAction(Action a);
	GameObject getGameObject(); //This is the game object that is being refered too, not sure if nesseary
}
