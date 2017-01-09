using UnityEngine;
using System.Collections;
using InControl;

public class Fireball_shadow : MonoBehaviour {
	
	public Vector3 center;
	
	// Update is called once per frame
	void FixedUpdate () {
		Transform trans = GameObject.Find ("FireCharacter").transform;
		transform.position = trans.position + 5 * trans.forward;
	}
	
}