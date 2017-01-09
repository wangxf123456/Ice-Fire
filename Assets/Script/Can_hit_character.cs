using UnityEngine;
using System.Collections;

public class Can_hit_character : MonoBehaviour {

	public int damage = 10;
	// Update is called once per frame
	void OnTriggerEnter (Collider col) {
		if (col.gameObject.GetComponent<Character> ()) {
			Character_health character = col.gameObject.GetComponent<Character_health> ();
			character.hit (damage);
		}
	}

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.GetComponent<Character> ()) {
			Character_health character_health = col.gameObject.GetComponent<Character_health> ();
			Character character = col.gameObject.GetComponent<Character> ();
			character_health.hit (damage);
			character.hit_recover(transform.position);
		}
	}
}
