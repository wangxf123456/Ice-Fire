using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public Vector3 desPos = Vector3.zero;
	public GameObject bullet;

	public float radius = 8f;

	public bool isMovable = true;

	private bool isThreat = false;
	private Vector3 oriPos;
	private int threatNum = 0;
	private Vector3 velocity;
	private float maxVel = 1f;
	private int timer = 0;
	private int attackTime = 60;

	// Use this for initialization
	void Start () {
		oriPos = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isMovable) {
			movableAttack ();
		}
		else {
			steadyAttack();
		}
	}

	void steadyAttack() {
		if (!isThreat) {
			float disPlayer1 = Vector3.Distance (transform.position, GamePosition.player1Pos);
			float disPlayer2 = Vector3.Distance (transform.position, GamePosition.player2Pos);
			
			if (disPlayer1 < radius) {
				isThreat = true;
				threatNum = 1;
			}
			else if (disPlayer2 < radius) {
				isThreat = true;
				threatNum = 2;
			}
			else {
				isThreat = false;
			}
			
			if (!isThreat) {
				timer = 0;
			}
		}
		else {
			Vector3 playerVec = getPlayerVector();
			float disPlayer = Vector3.Distance (transform.position, playerVec);
			
			if (disPlayer < radius) {
				transform.LookAt(playerVec);
				if (timer == 0 && bullet != null) {
					GameObject go = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
					timer = attackTime;
				}
				else {
					timer--;
				}
			}
			else {
				timer = 0;
				isThreat = false;
			}
		}
	}


	void movableAttack() {
		if (!isThreat) {
			float disEnemy = Vector3.Distance (oriPos, transform.position);
			float disPlayer1 = Vector3.Distance (transform.position, GamePosition.player1Pos);
			float disPlayer2 = Vector3.Distance (transform.position, GamePosition.player2Pos);
			
			if (disPlayer1 < radius) {
				isThreat = true;
				threatNum = 1;
			}
			else if (disPlayer2 < radius) {
				isThreat = true;
				threatNum = 2;
			}
			else {
				isThreat = false;
			}
			
			if (!isThreat) {
				if (disEnemy > 0.1f) {
					// move towards origin
					transform.LookAt(oriPos);
					velocity = Vector3.Normalize( oriPos - transform.position );
					Vector3 pos = transform.position;
					pos += velocity * maxVel * Time.deltaTime;
					transform.position = pos;
					timer = 0;
				}
			}
		}
		else {
			Vector3 playerVec = getPlayerVector();
			float disPlayer = Vector3.Distance (transform.position, playerVec);
			
			if (disPlayer < radius) {
				// move towards player
				transform.LookAt(playerVec);
				velocity = Vector3.Normalize(playerVec - transform.position);
				Vector3 pos = transform.position;
				pos += velocity * maxVel * Time.deltaTime;
				transform.position = pos;
				
				if (timer == 0 && bullet != null) {
					GameObject go = Instantiate(bullet, transform.position, transform.rotation) as GameObject;
					timer = attackTime;
				}
				else {
					timer--;
				}
			}
			else {
				timer = 0;
				isThreat = false;
			}
		}
	}

	Vector3 getPlayerVector() {
		Vector3 playerVec = Vector3.zero;
		if (threatNum == 1) {
			playerVec = GamePosition.player1Pos;
		}
		else if (threatNum == 2) {
			playerVec = GamePosition.player2Pos;
		}
		return playerVec;
	}

	void OnCollisionEnter (Collision col) {

	}
	
}