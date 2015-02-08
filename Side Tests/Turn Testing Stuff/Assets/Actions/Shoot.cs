using UnityEngine;
using System.Collections;

public class Shoot : AbstractAction {

	bool started = false;
	float completion = 0;
	Turnable target;

	public Shoot(Turnable t, Turnable target) : base(t){
		this.target = target;
	}
	
	public override void doAction(){
		if (started == false) {
			beginAction ();
		} else {
			continueAction();
		}
	}

	void beginAction(){
		completion += 0.5f;
		started = true;
		Debug.Log (user.getGameObject().name + ": AIMING");
	}

	void continueAction(){
		if (completion >= 1) {
			Debug.Log (user.getGameObject ().name + ": FIRING AT " + target.getGameObject().name);
			user.finishAction ();
		} else {
			completion += 0.5f;
			Debug.Log (user.getGameObject().name + ": AIMING");
		}
	}
}
