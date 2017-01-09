using UnityEngine;
using System.Collections;

public class WindowBlock : MonoBehaviour {
	public int windowNum;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		if (col.gameObject.GetComponent<Character> ()) {
			Pop_window.tutorial_num = windowNum;	
			Destroy(this.gameObject);
		}
	}

}
