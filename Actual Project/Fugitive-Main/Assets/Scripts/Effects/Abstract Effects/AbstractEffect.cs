using UnityEngine;
using System.Collections;

public abstract class AbstractEffect : IEffect {

	ITurnable target;

	public abstract void doEffect ();

	public AbstractEffect(ITurnable target){
		this.target = target;
	}
}
