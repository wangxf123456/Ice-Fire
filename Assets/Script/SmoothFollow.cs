using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour {
	
	public float distance = 5.0f;
	public float height = 2.0f;
	public float lowest = 5f;
	public float highest = 100;
	public Transform target1;
	public Transform target2;
	public float ZoomRate = 1f;
	public float xParam = 1f;
	public float zParam = 1f;
	bool moveable = true;
	float originDist;

	private GameObject line1;
	private GameObject line2;
	public GameObject lineObject;

	public Vector3 East = new Vector3(0,0,0);
	public Vector3 North  = new Vector3(0,0,0);
	
	// Use this for initialization
	void Start () {
		initLine ();
		this.transform.position = new Vector3 (0, getDistance () * ZoomRate + height, 0);
		this.transform.position = getCenter (true);
		originDist = getDistance ();
	}
	
	// Update is called once per frame
	void Update () {
		if (target1 && target2) {

			updateLine();

			// Look at and dampen the rotation
			Vector3 tempCenter = getCenter(true);
			if (!moveable)
			{
				//Debug.Log("LOWEST");
				tempCenter.y = lowest;
				tempCenter.x = (target1.position.x + target2.position.x) / 2 + distance * lowest / height * xParam;
				tempCenter.z = (target1.position.z + target2.position.z) / 2 + distance * lowest / height * zParam;
			}
			transform.position = tempCenter;
			var rotation = Quaternion.LookRotation(getCenter(false) - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 6);

			East.x = -distance * (1 + getDistance() * ZoomRate / height);
			North.z = distance * (1 + getDistance() * ZoomRate / height);
			
			East.z = distance * (1 + getDistance() * ZoomRate / height);
			North.x = distance * (1 + getDistance() * ZoomRate / height);
		}
		
	}

	void initLine(){
		line1 = (GameObject)Instantiate (lineObject, this.transform.position, Quaternion.identity);
		line2 = (GameObject)Instantiate (lineObject, this.transform.position, Quaternion.identity);


	}

	void updateLine(){

		Vector3 pos1 = target1.transform.position;
		Vector3 pos2 = target2.transform.position;
		Vector3 cameraPos = this.transform.position;

		//change scale
		Vector3 scale1 = line1.transform.localScale;
		Vector3 scale2 = line2.transform.localScale;
		scale1.z = (cameraPos - pos1).magnitude - 3f;
		scale2.z = (cameraPos - pos2).magnitude - 3f;
		line1.transform.localScale = scale1;
		line2.transform.localScale = scale2;

		//change the rotation
		line1.transform.LookAt (target1);
		line2.transform.LookAt (target2);

		//change position

		line1.transform.position = (pos1 + cameraPos) / 2f;
		line2.transform.position = (pos2 + cameraPos) / 2f;
	}
	
	float getDistance()
	{
		return Mathf.Sqrt (Mathf.Pow ((target1.position.x - target2.position.x), 2) + Mathf.Pow ((target1.position.z - target2.position.z), 2));
	}
	
	Vector3 getCenter(bool isCamera)
	{
		Vector3 tempCenter;
		
		if (!isCamera)
		{
			tempCenter.y = (target1.position.y + target2.position.y) / 2;
			tempCenter.x = (target1.position.x + target2.position.x) / 2;
			tempCenter.z = (target1.position.z + target2.position.z) / 2;
		}
		else
		{
			tempCenter.y = (getDistance() - originDist) * ZoomRate + height;
			//Debug.Log(getDistance());
			if (tempCenter.y  < lowest)
				moveable = false;
			else 
				moveable = true;
			tempCenter.x = (target1.position.x + target2.position.x) / 2 + distance * (1 + (getDistance() - originDist) * ZoomRate / height) * xParam;
			tempCenter.z = (target1.position.z + target2.position.z) / 2 + distance * (1 + (getDistance() - originDist) * ZoomRate / height) * zParam;

		}

		return tempCenter;
	}
}