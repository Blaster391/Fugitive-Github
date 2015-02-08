using UnityEngine;
using System.Collections;

public class Move : AbstractAction {

	bool started = false;
	float completion = 0; //When completion is 1, the action is finished.

    public Move(Turnable t) : base(t){}

	public override void doAction(){ //Start or continue the action
		if (started == false) {
			beginAction ();
		} else {
			continueAction();
		}
	}

	void beginAction(){
		Debug.Log (user.getGameObject().name +  ": Started Moving");
		completion += 0.25f;
		started = true;
	}

	void continueAction(){
		if(completion < 1){
			Debug.Log (user.getGameObject().name +  ": Moving " + completion);
			completion += 0.25f;
		}
		else{
			Debug.Log (user.getGameObject().name +  ": Finished");
			user.finishAction();
		}
	}
}
