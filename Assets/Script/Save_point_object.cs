using UnityEngine;
using System.Collections;

public class Save_point_object : MonoBehaviour {

	public int position = 0;

	// Use this for initialization
	void Start () {
		if (GameMaster.position > position) {
			Destroy(gameObject);
		}
	}

}
