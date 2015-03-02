using UnityEngine;
using System.Collections;

public class BasicMove : AbstractAction {


	public BasicMove() : AbstractAction(){

	}

	public override void doAction (){
		Debug.Log ("Moving");
	}
	public override void cancelAction(){

	}
}
