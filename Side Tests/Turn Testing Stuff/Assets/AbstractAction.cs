using UnityEngine;
using System.Collections;

public abstract class AbstractAction : Action {

	public Turnable user;

	public AbstractAction(Turnable user){
		this.user = user;
	}
	
	public abstract void doAction();
	public abstract Turnable getUser();
}
