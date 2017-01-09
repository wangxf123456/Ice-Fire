using UnityEngine;
using System.Collections;

public class LoadNext : MonoBehaviour {

	public string nextLevel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.GetComponent<Character>()){
			Application.LoadLevel(nextLevel);
		}
	}
}
