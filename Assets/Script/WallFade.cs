using UnityEngine;
using System.Collections;

public class WallFade : MonoBehaviour {

	public int num = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		float trans = this.gameObject.renderer.material.color.a;
		if(num  == 0 && trans < 1){
			trans += 0.02f;
			this.gameObject.renderer.material.color = new Color(1,1,1,trans);
		}
		
		if(num == 1 && trans > 0.2f){
			trans -= 0.01f;
			this.gameObject.renderer.material.color = new Color(1,1,1,trans);
		}
	
	}
}
