using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.GetComponent<Character> ()) {
			Character_health character_health = col.gameObject.GetComponent<Character_health> ();
			character_health.health += 10;
			Destroy(gameObject);
		}
	}
}
