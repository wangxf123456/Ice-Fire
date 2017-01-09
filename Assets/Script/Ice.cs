using UnityEngine;
using System.Collections;

public class Ice : MonoBehaviour {
	public GameObject iceObject;

	private float speed = 0.05f;
	public Vector3 dir;
	private float secondsUntilDestroy = 1f;
	private float startTime;
	
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.position += speed * dir;
		
		if (Time.time - startTime >= secondsUntilDestroy) {
			Destroy(this.gameObject);
		} 
	}
	
	void OnTriggerEnter(Collider col) {
		if (col.transform.GetComponent<CanGenerateIce>() && !col.transform.GetComponent<CanGenerateIce>().getIsFreezed()) {

		
			if (col.transform.GetComponent<EnemyDamageTaken>()) {
				col.transform.GetComponent<EnemyDamageTaken>().takeDamage(30);
				col.transform.GetComponent<Enemy>().setThreatNum(2);
				
				Destroy(this.gameObject); 
			}
			
			

			Vector3 pos = col.transform.GetComponent<CanGenerateIce>().transform.position;
			GameObject ice = (GameObject)Instantiate (iceObject, pos, Quaternion.identity);
			Vector3 size = col.transform.GetComponent<CanGenerateIce>().collider.bounds.size;
			ice.transform.localScale = size * 1.5f;
			ice.transform.GetComponent<IceObject>().target = col.transform.GetComponent<CanGenerateIce>();
			col.transform.GetComponent<CanGenerateIce>().GetComponent<CanGenerateIce>().isFreezeMove (true);
		}
	}
}