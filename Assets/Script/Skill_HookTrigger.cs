using UnityEngine;
using System.Collections;
using InControl;

public class Skill_HookTrigger : MonoBehaviour {
	
	public bool isHooked;
	public bool isAttached;
	public Transform chainPref;
	public Transform signPref;
	public int chainVelocity = 40;
	GameObject chain;
	float hookTimer = 0.8f;
	float hookTime = 0.8f;
	GameObject attachedObject;
	Vector3 velocity;
    bool canHookAgain = false;
	bool isJump = false;
	Vector3 tempPos;
	GameObject signObject;
	float secondHookTimer = 1f;
	float secondHookReady = 1f;
	bool isSecondTiming = false;

	private InputDevice control;

	public GameObject line;
	private GameObject lineGO;
	private bool isLine = false;
	private float maxAngle = 20f;


	private int cdTimer = 0;

	// Use this for initialization
	void Start () {
		isHooked = false;
		print ("start!");
		if (InputManager.Devices.Count == 2) {
			control = InputManager.Devices[1];
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(cdTimer >0){
			cdTimer--;
		}

		if(isAttached && !attachedObject){
			hookAbandon();
			return;
		}

		if (signObject) {
			signObject.transform.position = attachedObject.transform.position;
		}

		if (InputManager.Devices.Count == 2) {
			control = InputManager.Devices[1];
		}

		if (control != null) {
			if (control.Action3.IsPressed && isHooked == false && isLine == false && cdTimer == 0) {
				Quaternion rotation = transform.rotation;
				Vector3 angle = rotation.eulerAngles;
				angle.y -= 90;
				float maxAngle = 20f;
				rotation.eulerAngles = angle;
				lineGO = Instantiate(line, transform.position, rotation) as GameObject;
				isLine = true;
//				GetComponent<Character>().unmovable = true;
//				GetComponent<Character>().isLine = true;
				print (GetComponent<Character>().unmovable);
			}
			else if (control.Action3.WasReleased && isHooked == false && cdTimer == 0) {
				Destroy(lineGO);
				//GetComponent<Character>().isLine = false;
				//GetComponent<Character>().unmovable = false;
				isLine = false;
				Vector3 direction =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
				hook();
			}
		}
		else {
			if (Input.GetKeyDown("c") && isHooked == false && isLine == false && cdTimer == 0) {
				Quaternion rotation = transform.rotation;
				Vector3 angle = rotation.eulerAngles;
				angle.y -= 90;
				float maxAngle = 20f;
				rotation.eulerAngles = angle;
				lineGO = Instantiate(line, transform.position, rotation) as GameObject;
				isLine = true;
			}
			else if (Input.GetKeyUp("c") && isHooked == false && cdTimer == 0) {
				Destroy(lineGO);
				isLine = false;
				Vector3 direction =  Camera.main.ScreenToWorldPoint(Input.mousePosition);
				hook();
			}
		}



	
		if (Input.GetKeyDown(KeyCode.H) && isHooked == true) {
			hookAbandon();
		}

		if (isSecondTiming && secondHookTimer <= 0)
			hookAbandon();
	
		if (hookTimer <= 0.03f)
			resetTimer();

		//Attach end
		//if (isAttached && (hookTimer <= 0.03f))
		//	resetTimer();
		
		//Attached
		if (isAttached && !canHookAgain) {
			secondHookTimer = secondHookReady;
			isSecondTiming = true;
			showSign();
			canHookAgain = true;
			return;
		}

		if (canHookAgain)
			secondHookTimer -= Time.fixedDeltaTime;

		//Hook Second
		if (control != null && control.Action3 && canHookAgain && cdTimer == 0) {
			
			isSecondTiming = false;
			
			// Attack enemy, drag it for a short distance
			if (attachedObject && attachedObject.GetComponent<Enemy>()) {
				chain.GetComponent<Skill_HookMovement>().secondAttack ();
			}
			
			// Jump to another character
			if (attachedObject && attachedObject.GetComponent<Rush>()) {
				tempPos = attachedObject.transform.position;
				isJump = true;
				//Debug.Log("JUMPING");
				rigidbody.AddForce(Vector3.up * 1800);
			}
			
			isAttached = false;
			canHookAgain = false;
			cancelSign();
			cdTimer = 60;

		}
		else if (canHookAgain && control == null && Input.GetKeyDown (KeyCode.C)) {

			isSecondTiming = false;

			// Attack enemy, drag it for a short distance
			if (attachedObject.GetComponent<Enemy>()) {
				chain.GetComponent<Skill_HookMovement>().secondAttack ();
			}

			// Jump to another character
			if (attachedObject.GetComponent<Rush>()) {
				tempPos = attachedObject.transform.position;
				isJump = true;
				//Debug.Log("JUMPING");
				rigidbody.AddForce(Vector3.up * 1800);
			}

			isAttached = false;
			canHookAgain = false;
			cancelSign();

			cdTimer = 120;
		}

		/*if (Input.GetKeyDown (KeyCode.J) && (hookTimer >= hookTime)) {
			tempPos = transform.position;
			tempPos += transform.forward * 10;
			isJump = true;
			Debug.Log("JUMPING");
			rigidbody.AddForce(Vector3.up * 1800);
		}*/

		if (isJump) {
			velocity = (tempPos - transform.position)/hookTimer;
			Vector3 pos = transform.position;
			pos.x += velocity.x * Time.fixedDeltaTime;
			pos.z += velocity.z * Time.fixedDeltaTime;
			rigidbody.AddForce(Vector3.down * 35);

			//print (hookTimer);
			transform.position = pos;
			hookTimer -= Time.deltaTime;
		}

	}

	void showSign() {
		if(attachedObject){
			signObject = ((Transform)Instantiate (signPref, attachedObject.transform.position, Quaternion.identity)).gameObject;
		}
	}

	void cancelSign() {
		if (signObject != null)
		    Destroy (signObject);
	}


	void hook(){
		Vector3 dir = this.transform.forward;

		if (lineGO != null) {
			dir = lineGO.transform.right;		
		}

		dir.y = 0;
		Vector3 pos = this.transform.position + this.transform.localScale.x / 1.6f * dir;
		chain = ((Transform)Instantiate (chainPref, pos, Quaternion.identity)).gameObject;
		chain.GetComponent<Skill_HookMovement>().origin = this.transform;
		chain.GetComponent<Skill_HookMovement> ().velocity = dir * chainVelocity;
		chain.GetComponent<Skill_HookMovement> ().parent = this;
		isHooked = true;
	}
	
	public void hookAttach(GameObject attachedMonsterObj){
		GetComponent<Character>().isLine = false;
		GetComponent<Character>().unmovable = false;
		isAttached = true;
		//isHooked = false;
		attachedObject = attachedMonsterObj;
		
	}
	
	public void hookAbandon() {
		setAbandon ();
		chain.GetComponent<Skill_HookMovement> ().hookAbandon ();
	}
	
	public void setAbandon() {
		GetComponent<Character>().isLine = false;
		GetComponent<Character>().unmovable = false;
		isHooked = false;
		isAttached = false;
		isJump = false;
		hookTimer = hookTime;
		isSecondTiming = false;
		cancelSign ();
		canHookAgain = false;
	}
	
	private void resetTimer() {
		hookAbandon ();
	}
}

