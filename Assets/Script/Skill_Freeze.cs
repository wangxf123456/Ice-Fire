using UnityEngine;
using System.Collections;
using InControl;

public class Skill_Freeze : MonoBehaviour {
	public GameObject ice;
	private int timer = 0;

	private InputDevice control;

	// Use this for initialization
	void Start () {
		if (InputManager.Devices.Count == 2) {
			control = InputManager.Devices[1];
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (InputManager.Devices.Count == 2) {
			control = InputManager.Devices[1];
		}

		if (timer > 0) {
			timer--;
		}
		if (timer == 0) {
			if (control != null && control.Action2) {
				timer = 120;	
				Vector3 origin = this.transform.position;
				float startR = 2f;
				
				float effectRadius = 3f;
				float angle = 2 * Mathf.PI / 16;
				Vector3 xAxis = new Vector3(1, 0, 0);
				Vector3 zAxis = new Vector3(0, 0, 1);
				
				Vector3 rotAngle = transform.eulerAngles;
				Quaternion rotation = transform.rotation;
				
				
				// rotation.eulerAngles = rotAngle;
				
				for (float theta = 0; theta < 2 * Mathf.PI; theta += 0.1f) {
					Vector3 dir = xAxis * Mathf.Sin (theta) * startR  + zAxis * Mathf.Cos (theta) * startR;
					Vector3 pos = origin + dir;
					rotAngle.y += (360 / (2 * Mathf.PI / 0.1f) );
					rotation.eulerAngles = rotAngle;
					
					GameObject icePiece = (GameObject)Instantiate(ice, pos, rotation);
					icePiece.transform.GetComponent<Ice>().dir = dir;
				}
			}
			else if (control == null && Input.GetKeyDown(KeyCode.Z)) {
				timer = 120;	
				Vector3 origin = this.transform.position;
				float startR = 2f;

				float effectRadius = 3f;
				float angle = 2 * Mathf.PI / 16;
				Vector3 xAxis = new Vector3(1, 0, 0);
				Vector3 zAxis = new Vector3(0, 0, 1);

				Vector3 rotAngle = transform.eulerAngles;
				Quaternion rotation = transform.rotation;


				// rotation.eulerAngles = rotAngle;

				for (float theta = 0; theta < 2 * Mathf.PI; theta += 0.1f) {
					Vector3 dir = xAxis * Mathf.Sin (theta) * startR  + zAxis * Mathf.Cos (theta) * startR;
					Vector3 pos = origin + dir;
					rotAngle.y += (360 / (2 * Mathf.PI / 0.1f) );
					rotation.eulerAngles = rotAngle;
					
					GameObject icePiece = (GameObject)Instantiate(ice, pos, rotation);
					icePiece.transform.GetComponent<Ice>().dir = dir;
				}
			}
		}
	}
}

