using UnityEngine;
using System.Collections;

public class Enemy_tanhao : MonoBehaviour {

	private int timer = 60;
	public GameObject tanhao;

	void Start () {
		show ();
	}

	public void show() {
		Vector3 pos = transform.position;
		print (pos);
		Vector3 pos1 = Camera.main.WorldToViewportPoint(pos);
		Destroy(Instantiate(tanhao, pos1, Quaternion.Euler(0, 0, 0)), 1.0f);
	}
}
