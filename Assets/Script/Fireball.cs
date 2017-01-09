using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {
	public GameObject ballFlame;
	private float startTime;
	private float vel = 0;
	private float velG = 0;
	private bool isGround = false;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.time - startTime >= 1f) {
			Destroy(this.gameObject);
		} 
		
		else {
			Vector3 pos = transform.position;
			if (!isGround) {
				vel += 25 * Time.deltaTime;
				velG += 9.8f * Time.deltaTime;
			}
			else {
				vel = -25;
			}
			pos -= transform.up * vel * Time.deltaTime;
			transform.position = pos;
		}
	}
	
	void OnTriggerEnter(Collider col) {
		if (col.transform.GetComponent<Ground>()) {
			
			Vector3 effectOrigin = this.transform.position;
			// effectOrigin.y = 0.5f;
			float effectRadius = 3f;
			float angle = 2 * Mathf.PI / 8;
			Vector3 xAxis = new Vector3(1, 0, 0);
			Vector3 zAxis = new Vector3(0, 0, 1);
			
			for (int i = 0; i < 8; i++) {
				Vector3 pos = effectOrigin + xAxis * Mathf.Sin (angle * i) * effectRadius + zAxis * Mathf.Cos (angle * i) * effectRadius;
				Destroy ((GameObject)Instantiate(ballFlame, pos, transform.rotation), 0.8f);
			}
			isGround = true;
			
		}
		else if (col.transform.GetComponent<EnemyDamageTaken>()) {
			col.transform.GetComponent<EnemyDamageTaken>().takeDamage(50);
			if(col.transform.GetComponent<Enemy>()){
				col.transform.GetComponent<Enemy>().setThreatNum(1);
			}
			
		}
		
	}
}