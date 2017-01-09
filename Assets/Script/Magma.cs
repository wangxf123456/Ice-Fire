using UnityEngine;
using System.Collections;

public class Magma : MonoBehaviour {

	public string level;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if(col.GetComponent<Character>()){
			Character_health character = col.gameObject.GetComponent<Character_health> ();
			character.hit (50);
			if (col.gameObject.name == "FireCharacter") {
				col.gameObject.transform.position = GameMaster.fire_fall_pos;
			} else if (col.gameObject.name == "IceCharacter") {
				col.gameObject.transform.position = GameMaster.ice_fall_pos;
			}

		}
	}
}
