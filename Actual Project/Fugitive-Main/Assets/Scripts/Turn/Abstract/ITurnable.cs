using UnityEngine;
using System.Collections;

public interface ITurnable {
	void takeTurn();
	void doEffects();
	void register();
	void remove();
}
