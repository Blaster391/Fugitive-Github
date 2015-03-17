using UnityEngine;
using System.Collections;

public interface ITurnable {
	void takeTurn();
	void doEffects();
	void addEffect(IEffect effect);
	void register();
	void remove();
}
