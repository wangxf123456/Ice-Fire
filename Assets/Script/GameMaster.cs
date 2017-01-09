using UnityEngine;
using System.Collections;
using InControl;

public class GameMaster : MonoBehaviour {
	
	private int fireLife;
	private int iceLife;
	public GameObject HP_fire;
	public GameObject HP_ice;
	public GameObject HP_player_background1;
	public GameObject HP_player_background2;
	public GameObject HP_fire_num;
	public GameObject HP_ice_num;
	public GameObject fire_image;
	public GameObject ice_image;
	static public Vector3 fire_fall_pos = Vector3.zero;
	static public Vector3 ice_fall_pos = Vector3.zero;

	static public int position = 0;
	
	static private Vector3 position1_fire = new Vector3(-12.57454f, -2.936324f, -75.37047f);
	static private Vector3 position1_ice = new Vector3(-6.57454f, -2.936324f, -75.37047f);
	static private Vector3 position2_fire = new Vector3(-90.06372f, -2.994581f, -93.8201f);
	static private Vector3 position2_ice = new Vector3(-85.90354f, -2.692693f, -93.44726f);
	static private Vector3 position3_fire = new Vector3(-98.3213f, -1.932641f, -2.527148f);
	static private Vector3 position3_ice = new Vector3(-98.56313f, -1.9326413f, 2.040698f);
	
	private InputDevice control1;
	private InputDevice control2;
	private bool is_paused = false;
	// Use this for initialization
	
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
	
	void Start () {
		if (InputManager.Devices.Count == 1) {
			control1 = InputManager.Devices[0];
		}
		else if (InputManager.Devices.Count == 2) {
			control1 = InputManager.Devices[0];
			control2 = InputManager.Devices[1];
		}
		put_character ();
		if(HP_fire_num){
			HP_fire_num.guiText.pixelOffset = new Vector2(130, Screen.height * 0.9f + 25);
			HP_fire_num.guiText.text = "100/100";
		}
		if(HP_ice_num){
			HP_ice_num.guiText.pixelOffset = new Vector2 (Screen.width - 190, Screen.height * 0.9f + 25);
			HP_ice_num.guiText.text = "100/100";
		}
		if(HP_player_background1){
			HP_player_background1.guiTexture.pixelInset = new Rect (10, Screen.height * 0.9f, 300, 30);	
		}
		
		if(HP_player_background2){
			HP_player_background2.guiTexture.pixelInset = new Rect (Screen.width - 310, Screen.height * 0.9f, 300, 30);	
		}
		
		if(fire_image){
			fire_image.guiTexture.pixelInset = new Rect (10, Screen.height * 0.9f, 80, 80);	
		}
		
		if(ice_image){
			ice_image.guiTexture.pixelInset = new Rect (Screen.width - 310, Screen.height * 0.9f, 80, 80);	
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		if (InputManager.Devices.Count == 1) {
			control1 = InputManager.Devices[0];
		}
		else if (InputManager.Devices.Count == 2) {
			control1 = InputManager.Devices[0];
			control2 = InputManager.Devices[1];
		}
		pause ();
		if (GameObject.Find ("FireCharacter") && GameObject.Find("IceCharacter")) {
			Character_health fire = GameObject.Find ("FireCharacter").GetComponent<Character_health>();
			Character_health ice = GameObject.Find ("IceCharacter").GetComponent<Character_health>();
			if(HP_fire_num){
				fireLife = fire.get_health();
				iceLife = ice.get_health();	
				float ratio1 = (float)fireLife / (float)100;
				float ratio2 = (float)iceLife / (float)100;
				HP_fire_num.guiText.text = (ratio1 * 100).ToString() + "/100";
				HP_ice_num.guiText.text = (ratio2 * 100).ToString() + "/100";
				HP_fire.guiTexture.pixelInset = new Rect (10, Screen.height * 0.9f, ratio1 * 300, 30);
				HP_ice.guiTexture.pixelInset = new Rect (Screen.width - 310, Screen.height * 0.9f, ratio2 * 300, 30);	
			}
		}
		
		if (Input.GetKeyDown ("1")) {
			position = 1;
			put_character();
		}
		
		if (Input.GetKeyDown ("2")) {
			position = 2;
			put_character();
		}
		
		if (Input.GetKeyDown ("3")) {
			position = 3;
			put_character();
		}
	}
	
	public void put_character() {
		if (position == 1) {
			GameObject.Find ("FireCharacter").transform.position = position1_fire;
			GameObject.Find ("IceCharacter").transform.position = position1_ice;
		} else if (position == 2) {
			GameObject.Find ("FireCharacter").transform.position = position2_fire;
			GameObject.Find ("FireCharacter").transform.rotation = Quaternion.Euler(0, 0, 0);
			GameObject.Find ("IceCharacter").transform.position = position2_ice;
			GameObject.Find ("IceCharacter").transform.rotation = Quaternion.Euler(0, 0, 0);
		} else if (position == 3) {
			GameObject.Find ("FireCharacter").transform.position = position3_fire;
			GameObject.Find ("FireCharacter").transform.rotation = Quaternion.Euler(0, 270, 0);
			GameObject.Find ("IceCharacter").transform.position = position3_ice;
			GameObject.Find ("IceCharacter").transform.rotation = Quaternion.Euler(0, 270, 0);
		}
	}
	
	void pause() {
		if (control1 != null) {
			if (control1.MenuWasPressed) {
				Time.timeScale = 0;
				Camera.main.GetComponent<Pause_window>().enabled = true;
			}
		}
		if (control2 != null) {
			if (control2.MenuWasPressed) {
				Time.timeScale = 0;
				Camera.main.GetComponent<Pause_window>().enabled = true;
			}
		}
	}
}