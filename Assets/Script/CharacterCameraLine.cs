using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterCameraLine : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col){
		if(col.GetComponent<WallFade>()){
			col.GetComponent<WallFade>().num = 1;
		}
	}

	void OnTriggerStay(Collider col){
		OnTriggerEnter (col);
	}

	void OnTriggerExit(Collider col){
		if(col.GetComponent<WallFade>()){
			col.GetComponent<WallFade>().num = 0;
		}
	}
}
