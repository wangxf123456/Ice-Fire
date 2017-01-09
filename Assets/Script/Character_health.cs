using UnityEngine;
using System.Collections;

public class Character_health : MonoBehaviour {

	public int maxhealth = 100;
	public int health = 100;
	private int timer = 0;
	public string thisLevel;

	public void hit(int damage) {


		if (timer == 0) {
			timer = 60;
			health -= damage;
			Damage damage_object = GetComponent<Damage> ();
			damage_object.show_damage (damage);	
			if(health <= 0 ){
				GameMaster.position = 0;
				Application.LoadLevel("Start");
			}
		}
	}

	public int get_health() {
		return health;
	}

	void FixedUpdate () {
		if (timer > 0) {
			timer--;
		}
		if (health >= maxhealth) {
			health = maxhealth;
		}
	}
}
