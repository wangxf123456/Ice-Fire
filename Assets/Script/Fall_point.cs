using UnityEngine;
using System.Collections;

public class Fall_point : MonoBehaviour {

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.GetComponent<Character> ()) {
			if (col.gameObject.name == "FireCharacter") {
				GameMaster.fire_fall_pos = transform.position;
			} else if (col.gameObject.name == "IceCharacter") {
				GameMaster.ice_fall_pos = transform.position;
			}
		}
	}
}
