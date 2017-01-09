using UnityEngine;
using System.Collections;

public class BasicAttack_Bullet : MonoBehaviour {
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
			// Destroy(this.gameObject); 
		}
		else if(col.transform.GetComponent<EnemyDamageTaken>()) {
			col.transform.GetComponent<EnemyDamageTaken>().takeDamage(20);
			if(col.transform.GetComponent<Enemy>()){
				if (this.gameObject.name == "BulletFire(Clone)") {
					col.transform.GetComponent<Enemy>().setThreatNum(1);
				}
				else if (this.gameObject.name == "BulletIce(Clone)") {
					col.transform.GetComponent<Enemy>().setThreatNum(2);
				}	
			}

			Destroy(this.gameObject); 
		}
		else if(col.transform.GetComponent<IceObject>()) { 
			
		}
		else {
			Destroy(this.gameObject); 
		}
	}


}