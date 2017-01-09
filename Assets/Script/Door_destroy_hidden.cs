using UnityEngine;
using System.Collections;

public class Door_destroy_hidden : MonoBehaviour {
	
	void OnTriggerEnter (Collider col) {
		if (col.gameObject.GetComponent<Character_shadow> ()) {
			Destroy(transform.parent.gameObject);
		}
	}
	
}
