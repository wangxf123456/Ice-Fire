using UnityEngine;
using System.Collections;

public class KeyShowBoard : MonoBehaviour {

	public GameObject board;
	// Use this for initialization
	void Start () {
		board.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
		if(GetComponent<Enemy_health>().health <= 0){
			board.SetActive(true);
			Destroy(this.gameObject);
		}
	}
}
