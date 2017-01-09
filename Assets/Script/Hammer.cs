using UnityEngine;
using System.Collections;

public class Hammer : MonoBehaviour {

	public int startZ;
	void Start() {
		Vector3 rot = transform.rotation.eulerAngles;

		rot.z = startZ;
		transform.rotation = Quaternion.Euler (rot);
	}
		
	private bool increase = true;
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 rot = transform.rotation.eulerAngles;
		if (increase) {
			rot.z += 2;
		} else {
			rot.z -= 10;
		}

		if (rot.z >= 90 && rot.z <= 180) {
			increase = false;
		} else if (rot.z >= 325) {
			increase = true;
		}

		transform.rotation = Quaternion.Euler (rot);
	}
}
