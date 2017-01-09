using UnityEngine;
using System.Collections;

public class IceObject : MonoBehaviour {
	private float secondsUntilDestroy = 5f;
	private float startTime;
	public CanGenerateIce target;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time - startTime >= secondsUntilDestroy) {
			target.isFreezeMove(false);
			Destroy(this.gameObject);
		} 

		if(!target){
			Destroy(this.gameObject);
		}
	}	
}