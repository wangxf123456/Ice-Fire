using UnityEngine;
using System.Collections;

public class Food_shuzi : MonoBehaviour {
	
	private int timer = 60;

	void Start () {
		string temp = "+10";
		guiText.text = temp.ToString();
	}

	void FixedUpdate () {
		print ("shuzi updt4e");
		timer--;
		if (timer > 0) {
			if (timer % 2 == 0) {
				this.guiText.fontSize += 1;					
			}
			
		}
		if (timer <= 0) {
			if (timer % 3 == 0) {
				this.guiText.fontSize -= 1;
				Color color = this.guiText.color;
				color.a -= 0.05f;
				this.guiText.color = color;
			}	
		}
		
		if (this.guiText.fontSize <= 0) {			
			Destroy(this.gameObject);
		}
	}	
}
