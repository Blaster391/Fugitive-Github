using UnityEngine;
using System.Collections;

public class takeDamage : AbstractEffect {
	private int damage;

	public takeDamage(int damage, ITurnable target) : base(target){
		this.damage = damage;
	}

	public override void doEffect(){

	}
}
