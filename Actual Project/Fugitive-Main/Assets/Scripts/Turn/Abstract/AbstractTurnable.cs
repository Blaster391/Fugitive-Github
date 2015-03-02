using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class AbstractTurnable : MonoBehaviour, ITurnable{

	Queue<IEffect> effectQueue = new Queue<IEffect>();

	public abstract void takeTurn();

	public void doEffects(){

	}
	void register(){
		GameObject.Find ("GameMaster").GetComponent<TurnMaster> ().registerTurn (this);
	}
	void remove(){
		GameObject.Find ("GameMaster").GetComponent<TurnMaster> ().removeTurn (this);
	}
}
