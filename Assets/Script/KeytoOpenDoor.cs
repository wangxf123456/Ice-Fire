using UnityEngine;
using System.Collections;

public class KeytoOpenDoor : MonoBehaviour {

	public GameObject door;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(GetComponent<Enemy_health>().health <= 0){
			Destroy(door.gameObject);
			Destroy(this.gameObject);
		}
	}
}
