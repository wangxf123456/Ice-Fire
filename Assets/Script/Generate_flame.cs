using UnityEngine;
using System.Collections;

public class Generate_flame : MonoBehaviour {

	public GameObject flame;
	private int timer = 61;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (timer > 0) {
			timer--;
		} else {
			timer = -1;
		}

		if (timer % 5 == 0) {
			Destroy(Instantiate(flame, transform.position, transform.rotation), 0.5f);
		}
	}
}
