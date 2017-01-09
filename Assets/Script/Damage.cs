using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {

	public GameObject number;
	public int count = 0;
	// Use this for initialization
	void Start () {
		Damage_animation temp = number.GetComponent<Damage_animation>();
		temp.parent = this;
	}

	public void show_damage(int damage) {
		Vector3 pos = transform.position;
		pos.x += 0.4f * count * collider.bounds.size.x;
		pos.y += 0.4f * count * collider.bounds.size.y;
		Vector3 pos1 = Camera.main.WorldToScreenPoint(pos);
		Vector3 pos2 = Camera.main.ScreenToViewportPoint (pos1);
		Damage_animation temp = number.GetComponent<Damage_animation>();
		temp.count = count;
		temp.damage = damage;
		Instantiate(number, pos2, Quaternion.Euler(0, 0, 0));
		count++;
		if (count >= 5) {
			count = 0;
		}		
	}
}
