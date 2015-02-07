using UnityEngine;
using System.Collections;

public interface Turnable {
	void takeTurn();
	void registerTurnMaster();
	void addAction(Action a);
	void finishAction();
	void cancelAction(Action a);
	GameObject getGameObject();
}
