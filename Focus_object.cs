using UnityEngine;
using System.Collections;

public class Focus_object : MonoBehaviour {

	public int view = 20;
	
	void OnCollisionEnter (Collision col) {
		if(col.transform.GetComponent<Character>()){
			Camera.main.fieldOfView = view;
		} 	
	}
}
