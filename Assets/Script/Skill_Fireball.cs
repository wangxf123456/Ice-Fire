using UnityEngine;
using System.Collections;
using InControl;

public class Skill_Fireball : MonoBehaviour {
	public GameObject ball;
	public GameObject player;
	public GameObject ball_shadow;
	
	private float ballHeight = 10f;
	private float ballDistance = 6f;
	private GameObject ball_shadow_private;
	private GameObject ballGO;
	private int timer = 0;
	private int is_pressed = 0;
	
	private float vel = 0;
	
	private InputDevice control;
	
	// Use this for initialization
	void Start () {
		if (InputManager.Devices.Count > 0) {
			control = InputManager.Devices[0];
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (InputManager.Devices.Count > 0) {
			control = InputManager.Devices[0];
		}
		
		
		if (timer > 0) {
			timer--;
		}
		if (timer == 0) {
			if (control != null && control.Action2 && is_pressed == 0) {
				is_pressed = 1;
				Quaternion rot = Quaternion.Euler(0, 0, 0);
				ball_shadow_private = (GameObject)Instantiate(ball_shadow, transform.position + 5 * transform.forward, rot);	
			}
			else if (control == null && Input.GetKeyDown("e") && is_pressed == 0) {
				is_pressed = 1;
				Quaternion rot = Quaternion.Euler(0, 0, 0);
				ball_shadow_private = (GameObject)Instantiate(ball_shadow, transform.position + 5 * transform.forward, rot);
				ball_shadow_private.GetComponent<Fireball_shadow>().center = transform.position + 5 * transform.forward;
			}
		}
		
		if (control != null && control.Action2.WasReleased && is_pressed == 1) {
			timer = 120;
			is_pressed = 0;
			Vector3 ballStartPos = ball_shadow_private.transform.position + player.transform.up * ballHeight;
			ballGO = Instantiate(ball, ballStartPos, Quaternion.identity) as GameObject;
			vel = 0;
			Destroy(ball_shadow_private);
		} else if (control == null && Input.GetKeyDown("e") && is_pressed == 1) {
			timer = 120;
			is_pressed = 0;
			Vector3 ballStartPos = ball_shadow_private.transform.position + player.transform.up * ballHeight;
			ballGO = Instantiate(ball, ballStartPos, Quaternion.identity) as GameObject;
			vel = 0;
			Destroy(ball_shadow_private);
		}
		
		if (ballGO != null) {
			Vector3 pos = ballGO.transform.position;
			vel += 25 * Time.deltaTime;
			pos -= player.transform.up * vel * Time.deltaTime;
			ballGO.transform.position = pos;
		}
	}
}