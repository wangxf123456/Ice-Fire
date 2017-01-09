using UnityEngine;
using System.Collections;

public class CanGenerateIce : MonoBehaviour {
	private Vector3 freezePos;
	private bool isFreezed;

	// Use this for initialization
	void Start () {
		isFreezed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isFreezed) {
			this.transform.position = freezePos;
		}
	}

	public void isFreezeMove(bool freezeMove) {
		if (freezeMove) {
			freezePos = transform.position;
		}
		isFreezed = freezeMove;
	}

	public bool getIsFreezed() {
		return isFreezed;
	}
	
}
