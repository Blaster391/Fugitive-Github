using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractTurnable : MonoBehaviour, ITurnable{

	Queue<IEffect> effectQueue = new Queue<IEffect>();

	public abstract void takeTurn();

	public void doEffects(){
		while (effectQueue.Count > 0) {
			effectQueue.Dequeue().doEffect();
		}
	}
	public void addEffect(IEffect effect){
		effectQueue.Enqueue (effect);
	}

	public void register(){
		GameObject.Find ("GameMaster").GetComponent<TurnMaster> ().registerTurn (this);
	}
	public void remove(){
		GameObject.Find ("GameMaster").GetComponent<TurnMaster> ().removeTurn (this);
	}
}
