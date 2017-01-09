using UnityEngine;
using System.Collections;

public class LightCannon : MonoBehaviour {

	public GameObject ready;
	public GameObject bullet;
	private int timer = 0;

	void FixedUpdate () {
		if (timer > 0) {
			timer--;
		}

		if(timer == 0){
			timer = 180;
			startShootProcess();
		}
	}

	IEnumerator FinishReady(GameObject readyTran, float time){
		yield return new WaitForSeconds(time);
		Destroy (readyTran.gameObject);
		Vector3 pos = transform.position;
		pos.y = 1;
		Vector3 temp = new Vector3 (0, 120, 90);
		Vector3 boss_rot = transform.rotation.eulerAngles;
		boss_rot.x = 0;
		Quaternion rot = Quaternion.Euler(temp + boss_rot);

		GameObject bulletTran1 = (GameObject)Instantiate (bullet, pos, rot);
	
		temp = new Vector3 (0, 30, 90);
		rot = Quaternion.Euler(temp + boss_rot);
		GameObject bulletTran2 = (GameObject)Instantiate (bullet, pos, rot);

		yield return new WaitForSeconds(0.2f);
		Destroy (bulletTran1.gameObject);
		Destroy (bulletTran2.gameObject);
		yield break;
		yield break;
	}


	void startShootProcess(){
		Vector3 pos = transform.position;
		GameObject readyTran = (GameObject)Instantiate (ready, pos + transform.up * 4, Quaternion.identity);
		StartCoroutine (FinishReady (readyTran, 1.5f));
	}
}