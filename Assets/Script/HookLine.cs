using UnityEngine;
using System.Collections;
using InControl;

public class HookLine : MonoBehaviour {

	private InputDevice control;
	private float maxAngle = 20f;


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

		Quaternion rotation = GamePosition.player2Rot;
		Vector3 angle = rotation.eulerAngles;
		angle.y -= 90;

//		if (control != null) {
//			float inSweep = control.LeftStickX;
//			angle.y += (inSweep * maxAngle);
//		}

		rotation.eulerAngles = angle;
		transform.position = GamePosition.player2Pos;
		transform.rotation = rotation;
	}
}
