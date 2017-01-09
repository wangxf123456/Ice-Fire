using UnityEngine;
using System.Collections;

public class EnemyDamageTaken : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void takeDamage(int num){
		this.GetComponent<Enemy_health> ().hit (num);
		StartCoroutine (showStuck ());
	}

	IEnumerator showStuck(){
		this.GetComponent<OutlineObject> ().isOutlined = true;
		yield return new WaitForSeconds (0.5f);
		this.GetComponent<OutlineObject> ().isOutlined = false;
		yield break;
	}
}
