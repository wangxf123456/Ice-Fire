using UnityEngine;
using System.Collections;
using InControl;

public class Rush : MonoBehaviour {
	public GameObject shadow;
	
	private int rush_timer = 0;
	private float velocity = 0.1f;
	public float shadow_velocity = 5.0f;
	public int cd = 5;
	private int timer = 0;
	private int flame_timer = -1;
	private bool flame_state = false;
	private int is_released = 0;
	
	private InputDevice control;
	
	void start() {
		if (InputManager.Devices.Count > 0) {
			control = InputManager.Devices[0];
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
//		print (" " + is_released);
		if (InputManager.Devices.Count > 0) {
			control = InputManager.Devices[0];
		}
		
		if (timer > 0) {
			timer--;
		}
		
		if (flame_timer > 0) {
			flame_timer--;
		}
		
		if (flame_timer == 0) {
			rigidbody.velocity = Vector3.zero;
			GetComponent<Character>().unmovable = false;
			rigidbody.useGravity = true;
			flame_timer = -1;
		}
		
		if (control != null && control.Action3) {
			if (timer < 260 && GameObject.Find ("Character_shadow") && is_released == 2) {
				GameObject shadow = GameObject.Find ("Character_shadow");
				Vector3 dis = shadow.transform.position - transform.position;
				Destroy(shadow);
				rigidbody.velocity = 4 * dis / 1.0f;
				rigidbody.useGravity = false;
				flame_timer = 26;
				is_released = 0;
				GetComponent<Character>().unmovable = true;
			}
		} else if (control == null && Input.GetKeyDown("q")) {
			if (timer < 260 && GameObject.Find ("Character_shadow")) {
				GameObject shadow = GameObject.Find ("Character_shadow");
				Vector3 dis = shadow.transform.position - transform.position;
				Destroy(shadow);
				rigidbody.velocity = 4 * dis / 1.0f;
				flame_timer = 26;
				GetComponent<Character>().unmovable = true;
			}
		}
		
		if (control != null) {
			if (control.Action3.WasReleased && is_released == 1) {
				is_released = 2;
			}
		}
		
		if (timer <= 0 && flame_timer <= 0) {
			if (control != null && control.Action3 && !GameObject.Find ("Character_shadow")) {
				is_released = 1;
				shadow.rigidbody.velocity = shadow_velocity * transform.forward;
				timer = cd * 60;
				GameObject temp = (GameObject)Instantiate(shadow, transform.position, transform.rotation);
				temp.rigidbody.velocity = shadow_velocity * transform.forward;
				temp.name = "Character_shadow";
				Destroy(temp, cd);	
			}
			else if (control == null && Input.GetKeyDown("q") && !GameObject.Find ("Character_shadow")) {
				
				shadow.rigidbody.velocity = shadow_velocity * transform.forward;
				timer = cd * 60;
				GameObject temp = (GameObject)Instantiate(shadow, transform.position, transform.rotation);
				temp.rigidbody.velocity = shadow_velocity * transform.forward;
				temp.name = "Character_shadow";
				Destroy(temp, cd);	
			}
		}
	}
}