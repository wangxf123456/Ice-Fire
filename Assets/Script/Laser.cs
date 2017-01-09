using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
	
	public int damage = 10;
	public float interval = 1f;
	float intervalTimer = 0;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (intervalTimer <= 0)
			intervalTimer = interval;
		intervalTimer -= Time.fixedDeltaTime;
	}
	
	void OnParticleCollision(GameObject GO) {
		
		if (GO.GetComponent<Character> ()) {
			Character_health character_health = GO.GetComponent<Character_health> ();
			Character character = GO.GetComponent<Character> ();
			character_health.hit (damage);
			character.hit_recover(transform.position);
		}
	}
}