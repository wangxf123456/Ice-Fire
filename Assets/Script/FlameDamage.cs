using UnityEngine;
using System.Collections;

public class FlameDamage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col) {
		if (col.transform.GetComponent<EnemyDamageTaken>()) {
			col.transform.GetComponent<EnemyDamageTaken>().takeDamage(30);
			if(col.transform.GetComponent<Enemy>()){
				col.transform.GetComponent<Enemy>().setThreatNum(1);
			}
			
			Destroy(this.gameObject); 
		}
		
	}

}
