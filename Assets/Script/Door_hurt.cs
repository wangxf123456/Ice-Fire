using UnityEngine;
using System.Collections;

public class Door_hurt : MonoBehaviour {

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.GetComponent<Character> ()) {
			print ("gggg");
		}
	}
}
