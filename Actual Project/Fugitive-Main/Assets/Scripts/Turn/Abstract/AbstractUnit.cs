using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbstractUnit : AbstractTurnable {
	List<IAction> actionQueue = new List<IAction>();

	public override void takeTurn (){
		if (actionQueue.Count == 0) {
			return;
		}
		actionQueue [0].doAction ();
	}


}
