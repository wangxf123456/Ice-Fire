using UnityEngine;
using System.Collections;

public class Enemy_health : MonoBehaviour {

	public GameObject food;
	public int initial_health;
	public int health;
	private int timer = 600;
	// Use this for initialization
	void Start () {
		health = initial_health;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (timer > 0) {
			timer--;
		}

	}

	public void hit(int damage) {
		health -= damage;
		Damage damage_object = GetComponent<Damage> ();
		damage_object.show_damage (damage);
		if (health <= 0) {
			if(!GetComponent<KeytoOpenDoor>() && !GetComponent<KeyShowBoard>()){
				if (Random.Range(0f, 1f) > 0.5f) {
					Instantiate(food, transform.position, transform.rotation);
				}
				Destroy(gameObject);
			}
		}
	}
}
