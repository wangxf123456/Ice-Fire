using UnityEngine;
using System.Collections;

public class Damage_animation : MonoBehaviour {

	private int timer;
	public Damage parent;
	private bool is_increase = true;
	public int time = 60;
	public int font = 1;
	public int count = 0;
	public int damage = 0;
	// Use this for initialization
	void Start () {
		timer = time;
		guiText.text = damage.ToString();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer--;
		if (timer > 0) {
			if (timer % 2 == 0) {
				this.guiText.fontSize += font;					
			}

		}
		if (timer <= 0) {
			if (timer % 3 == 0) {
				this.guiText.fontSize -= font;
				Color color = this.guiText.color;
				color.a -= 0.05f;
				this.guiText.color = color;
			}	
		}

		if (this.guiText.fontSize <= 0) {
			if (count == 0) {
				if(parent){
					parent.count = count;	
				}		
			}

			Destroy(this.gameObject);
		}
	}
}
