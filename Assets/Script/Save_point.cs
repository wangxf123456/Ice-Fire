using UnityEngine;
using System.Collections;

public class Save_point : MonoBehaviour {

	public int position = 0;

	void OnCollisionEnter (Collision col) {
		if (col.gameObject.GetComponent<Character> ()) {
			GameMaster.position = position;
			Destroy(gameObject);
		}
	}
}
