using UnityEngine;
using System.Collections;

public class Character_shadow : MonoBehaviour {
	public int move_timer = 60;

	void FixedUpdate () {
		if (move_timer > 0) {
			move_timer--;
		}
		
		if (move_timer == 0) {
			rigidbody.velocity = Vector3.zero;		
		}
	}

	void OnCollisionEnter (Collision col) {
		if (col.transform.GetComponent<EnemyDamageTaken> ()) {
			col.transform.GetComponent<EnemyDamageTaken>().takeDamage(50);
			if(col.transform.GetComponent<Enemy>()){
				col.transform.GetComponent<Enemy>().setThreatNum(1);
			}		

		} else {
			rigidbody.velocity = Vector3.zero;		
		}
	}
}
