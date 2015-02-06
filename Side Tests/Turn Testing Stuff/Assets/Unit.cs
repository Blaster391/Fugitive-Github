using UnityEngine;
using System.Collections;

public class Unit : Turnable {

	public abstract void move(string dir);
	public abstract void shoot(Unit target);
}
