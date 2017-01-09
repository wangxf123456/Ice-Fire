using UnityEngine;
using System.Collections;

public class Skill_HookMovement : MonoBehaviour {
	[HideInInspector]
	public Transform origin;

	public Transform spotLighter;
	
	[HideInInspector]
	
	public int segments = 100;
	public float segmentLength;

	Particle[] particles;
	
	[HideInInspector]
	public Vector3 velocity;
	
	public Skill_HookTrigger parent;

	public float lengthLimit = 500;

	public bool isSecond = false;
	public bool isEnemy = false;
	float secondTimer = 0.1f;
	Vector3 fixedVelocity;

	Vector3 length = new Vector3(0, 0, 0);
	GameObject barLighter;

	GameObject attachedObject;

	float velocityIncrement = 15;

	// Use this for initialization
	void Start () {
		segmentLength = 1.0f / segments;
		particleEmitter.emit = false;
		
		particleEmitter.Emit (segments);
		particles = particleEmitter.particles;

		fixedVelocity = velocity;
	}
	
	public float bend = 0.00001f;
	public float maxHookMultiplier = 10f;
	
	// Update is called once per frame
	void Update () {
		if (!origin) {
			return;
		}
		Vector3 surfacePosition = Vector3.Normalize (this.transform.position - origin.position) *
			origin.localScale.x / 2 + origin.position;
		
		Vector3 perpendicular = Vector3.Normalize (Vector3.Cross(surfacePosition - this.transform.position
		                                                         ,Vector3.forward));
		float distance = (surfacePosition - this.transform.position).magnitude;

		for(int i = 0; i < particles.Length; i++) {
			Vector3 pos = Vector3.Lerp (surfacePosition, this.transform.position, segmentLength * i);
			float displacement = (Mathf.PerlinNoise(Time.time, i * segmentLength) - 0.5f) * bend *
				Mathf.Sqrt(distance) * (i * segmentLength) * (1 - i * segmentLength);
			particles[i].position = pos + displacement * perpendicular;
			particles[i].color = Color.magenta;
			particles[i].energy = 1f;
		}
		
		particleEmitter.particles = particles;
	}
	
	void FixedUpdate () {
		this.transform.position += velocity * Time.fixedDeltaTime;

		if (velocityIncrement >= 0) {
			Vector3 normalizedv = velocity.normalized;
			velocity += normalizedv * 100 * Time.fixedDeltaTime;
			velocityIncrement -= 100 * Time.fixedDeltaTime;
			//Debug.Log("Velocity = " + velocity);
		}

		length += velocity * Time.fixedDeltaTime;
		//Debug.Log (length.magnitude);

		if (velocity == Vector3.zero && attachedObject) {
			transform.position = attachedObject.transform.position;
		}

		if (length.magnitude >= lengthLimit) {
			hookAbandon ();
		}
		if (secondTimer <= 0) {
			//*****Enemy Attack
			Debug.Log("Attack Enemy 2");
			if(attachedObject && attachedObject.GetComponent<EnemyDamageTaken>()){
				attachedObject.GetComponent<EnemyDamageTaken>().takeDamage(80);
				attachedObject.transform.GetComponent<Enemy>().setThreatNum(2);
				
			}
			Debug.Log("Abandon");
			hookAbandon();
		}
		if (isSecond) {
			if(attachedObject){
				Vector3 tempPos = attachedObject.transform.position + velocity * Time.fixedDeltaTime;
				attachedObject.transform.position = tempPos;
			}

			secondTimer -= Time.fixedDeltaTime;
			//Debug.Log(secondTimer);
		}
	}
	
	void OnTriggerEnter(Collider col) {
		Debug.Log ("Triggered" + col.gameObject);
		attachedObject = col.gameObject;
		if (attachedObject.GetComponent<Skill_HookTrigger>() != null) {
			if (attachedObject.GetComponent<Skill_HookTrigger>() == parent) 
				return;
		}
		
		if (attachedObject.GetComponent<CanBeHooked>()) {
			print ("attached");
			parent.hookAttach (attachedObject);
			velocity = Vector3.zero;

			if (attachedObject.GetComponent<Enemy>()) {
				Debug.Log("Attack Enemy 1");
				attachedObject.GetComponent<EnemyDamageTaken>().takeDamage(40);
				attachedObject.GetComponent<Enemy>().setThreatNum(2);
				//Vector3 direction = new Vector3(parent.transform.position.x - transform.position.x, parent.transform.position.y - transform.position.y, parent.transform.position.z - transform.position.z);
				//direction.Normalize();
				//GO.rigidbody.AddForce(direction * 200);
			}
		}
		else {
			hookAbandon();
		}
	}

	public void secondAttack() {
		isSecond = true;
		velocity = -fixedVelocity;
	}
	
	public void hookAbandon() {
		Vector3 tempPos = parent.gameObject.transform.position;
		tempPos.x = (tempPos.x + transform.position.x) / 2;
		tempPos.y = (tempPos.y + transform.position.y) / 2;
		tempPos.z = (tempPos.z + transform.position.z) / 2;
		barLighter = ((Transform)Instantiate (spotLighter, tempPos, Quaternion.identity)).gameObject;
		Vector3 debugScale = new Vector3 ((transform.position.x - tempPos.x) * 0.8f, barLighter.transform.localScale.y, (transform.position.z - tempPos.z)*0.8f);
		barLighter.transform.localScale = debugScale;
		isSecond = false;
		attachedObject = null;
		parent.setAbandon();
		Destroy (this.gameObject);
	}

}
