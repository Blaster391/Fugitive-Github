using UnityEngine;
using System.Collections;

public class BasicMove : AbstractAction {


	public BasicMove(ITurnable user) : base(user){

	}

	public override void doAction (){
		Debug.Log ("Moving");
	}
	public override void cancelAction(){

	}
}
