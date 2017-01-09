using UnityEngine;
using System.Collections;

public class Food_animation : MonoBehaviour {

	public GameObject number;

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.GetComponent<Character> ()) {
			Vector3 pos = transform.position;
			Vector3 pos1 = Camera.main.WorldToViewportPoint(pos);
			Instantiate(number, pos1, Quaternion.Euler(0, 0, 0));
		}
	}
}
