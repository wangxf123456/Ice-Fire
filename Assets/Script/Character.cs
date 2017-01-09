using UnityEngine;
using System.Collections;
using InControl;

public class Character : MonoBehaviour {

	public GameObject camera;
	public int controllerNum;
	public GameObject bullet;
	
	private float velocity = 5f;
	private int attackTimer = 0;
	private InputDevice control;
	public bool isJump = false;
	private float jumpForce = 1.5f;
	public bool unmovable = false;
	private int hit_recover_timer = -1;
	public bool isLine = false;
	public int hitForce = 2000;

	private bool isSpin = false;
	// Use this for initialization
	void Start () {
		if (controllerNum < InputManager.Devices.Count) {
			control = InputManager.Devices[controllerNum];
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (hit_recover_timer > 0) {
			hit_recover_timer--;
		}

		if (hit_recover_timer == 0 && !isLine) {
			unmovable = false;
			hit_recover_timer = -1;
		}

		if (controllerNum < InputManager.Devices.Count) {
			control = InputManager.Devices[controllerNum];
		}
		if(!unmovable){
			CharacterMove ();
			CharacterJump ();
		}
		BasicAttack ();
			
		if (controllerNum == 0) {
			GamePosition.player1Pos = transform.position;
		}
		else if (controllerNum == 1) {
			GamePosition.player2Pos = transform.position;
			GamePosition.player2Rot = transform.rotation;
			GamePosition.player2Forward = transform.forward;		
		}
	}

	void OnCollisionEnter(Collision col){
		if (col.transform.GetComponent<Ground>()) {

			ContactPoint[] point = col.contacts;
			if(point.Length == 0 ){
				return;
			}
			float yAxis = point[0].point.y;
			for(int i =1 ; i < point.Length; i++){
				if(Mathf.Abs(point[i].point.y - yAxis) > 0.02f){;
					return;
				}
			}

			if(yAxis < this.transform.position.y){
				isJump = false;
			}
		}

	}

	void OnCollisionStay(Collision col){
		OnCollisionEnter (col);
	}

	void CharacterJump() {
		if (!isJump) {
			// Button A
			if (control != null && control.Action1) {
				isJump = true;
				Vector3 up = new Vector3(0,300,0);
				this.rigidbody.AddForce(up * jumpForce);
			}else if(control == null && Input.GetKeyDown("s")){
				isJump = true;
				Vector3 up = new Vector3(0,300,0);
				this.rigidbody.AddForce(up * jumpForce);
			}
		}
	}

	void CharacterMove() {
		float thumbstickDeadZone1 = 0.5f;
		float thumbstickDeadZone2 = 0.7f;
		Vector3 pos = transform.position;
		float velocity = 7f;
		Vector3 East = camera.GetComponent<SmoothFollow> ().East;
		Vector3 North = camera.GetComponent<SmoothFollow> ().North;
		
		float inX = 0f;
		float inY = 0f;
		//float maxAngle = 1;
		
		float spinX = 0f;
		float spinY = 0f;
		
		//float inR = 0f;
		
		if (control != null) {
			inX = control.LeftStickX;
			inY = control.LeftStickY;
			//inR = control.RightStickX;
			spinX = control.RightStickX;
			spinY = control.RightStickY;
		}
		
		Vector3 vel = Vector3.zero;
		
		if (Mathf.Abs (inY) > thumbstickDeadZone1 && !isSpin) {
			vel -= inY * North;
			
		}
		if (Mathf.Abs (inX) > thumbstickDeadZone1 && !isSpin) {
			vel += inX * East;
		}
		
		vel = vel.normalized * velocity;
		vel.y = rigidbody.velocity.y;
		rigidbody.velocity = vel;
		
		
		
		Vector3 des = Vector3.zero;
		des -= spinY * North;
		des += spinX * East;
		
		
		if (Mathf.Sqrt (Mathf.Pow (spinX, 2.0f) + Mathf.Pow (spinY, 2.0f)) > thumbstickDeadZone2) {
			des = des.normalized;
			transform.LookAt (pos + des);
		}
		
		
		
		
		
		
		//Vector3 angle = transform.eulerAngles;
		//Quaternion rotation = transform.rotation;
		//if (inR > thumbstickDeadZone2) {
		//angle.y += maxAngle;
		//isSpin = true;
		//}
		//else if (inR < -thumbstickDeadZone2) {
		//angle.y -= maxAngle;
		//isSpin = true;
		//
		//}
		//else {
		//isSpin = false;
		//}
		
		//rotation.eulerAngles = angle;
		//transform.rotation = rotation;
	}



	void BasicAttack() {
		float thumbstickDeadZone = 0.8f;
		float maxAngle = 20;

		if (attackTimer > 0) {
			attackTimer--;		
		}

		if (control != null && control.RightTrigger > thumbstickDeadZone && attackTimer == 0) {
			attackTimer = 40;
			Vector3 angle = transform.eulerAngles;
			Quaternion rotation = transform.rotation;

//			float inSweep = control.RightStickX;
//			angle.y += (inSweep * maxAngle);
//			rotation.eulerAngles = angle;
			GameObject go = Instantiate(bullet, transform.position, rotation) as GameObject;
		}
	}

	public void hit_recover(Vector3 pos) {
		if (hit_recover_timer <= 0) {
			unmovable = true;
			rigidbody.AddForce(1000 * (transform.position - pos).normalized);
			hit_recover_timer = 60;
		}
	}
}