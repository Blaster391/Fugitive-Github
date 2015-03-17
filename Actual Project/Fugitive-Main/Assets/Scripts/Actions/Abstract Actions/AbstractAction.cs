using UnityEngine;
using System.Collections;

public abstract class AbstractAction : MonoBehaviour ,IAction {

	ITurnable user;

	public AbstractAction(ITurnable user){
		this.user = user;
	}

	public abstract void doAction();
	public abstract void cancelAction();

}
