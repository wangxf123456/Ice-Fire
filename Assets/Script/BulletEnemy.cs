using UnityEngine;
using System.Collections;

public class BulletEnemy : MonoBehaviour {
	public float speed;
	public float secondsUntilDestroy;
	
	private float startTime;
	
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.position += speed * this.gameObject.transform.forward;
		
		if (Time.time - startTime >= secondsUntilDestroy) {
			Destroy(this.gameObject);
		} 
	}
	
	void OnTriggerEnter(Collider col) {
		
		if (col.transform.GetComponent<Character>()){
			Destroy(this.gameObject); 
		}
		else {

		}
	}
	
	
}
