using UnityEngine;
using System.Collections;

public class Focus_object : MonoBehaviour {

	public int view = 20;
	public float xParam = 1f;
	public float zParam =1f;
	
	void OnTriggerEnter (Collider col) {
		if(col.transform.GetComponent<Character>()){
			Camera.main.fieldOfView = view;
			Camera.main.transform.GetComponent<SmoothFollow>().xParam = xParam;
			Camera.main.transform.GetComponent<SmoothFollow>().zParam = zParam;
		} 	
	}
}
