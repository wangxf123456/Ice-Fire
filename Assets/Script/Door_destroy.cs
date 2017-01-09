using UnityEngine;
using System.Collections;

public class Door_destroy : MonoBehaviour {
	void OnCollisionEnter (Collision col) {
		if (col.gameObject.GetComponent<Character_shadow> ()) {
			Destroy(gameObject);
		}
	}
}
