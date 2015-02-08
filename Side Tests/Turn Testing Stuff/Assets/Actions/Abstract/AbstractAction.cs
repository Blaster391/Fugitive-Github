using UnityEngine;
using System.Collections;

public abstract class AbstractAction : Action {

	public Turnable user; //This is the character that is doing the action

	public AbstractAction(Turnable user){
		this.user = user;
	}
	
	public abstract void doAction();
}
