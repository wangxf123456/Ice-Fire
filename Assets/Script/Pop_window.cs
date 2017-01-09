using UnityEngine;
using System.Collections;
using InControl;

public class Pop_window : MonoBehaviour {
		
	public Rect windowRect = new Rect(0, 0, 5000, 5000);
	public Texture t1;
	public Texture t2;
	public Texture t3;
	public Texture t4;
	public Texture t5;
	public Texture t6;
	public Texture t7;
	public Texture t8;
	static public int tutorial_num = -1;

	private GUIStyle style0;

	private InputDevice control1;
	private InputDevice control2;

	public GameObject fireCharacter;
	public GameObject iceCharacter;




	void Start () {
		tutorial_num = -1;
		if (InputManager.Devices.Count == 1) {
			control1 = InputManager.Devices[0];
		}
		else if (InputManager.Devices.Count == 2) {
			control1 = InputManager.Devices[0];
			control2 = InputManager.Devices[1];
		}
	}

	void OnGUI() {
		if (InputManager.Devices.Count == 1) {
			control1 = InputManager.Devices[0];
		}
		else if (InputManager.Devices.Count == 2) {
			control1 = InputManager.Devices[0];
			control2 = InputManager.Devices[1];
		}
		style0 = new GUIStyle (GUI.skin.textField);
		style0.fontSize = 50;
		style0.normal.textColor = Color.red;
		style0.alignment = TextAnchor.UpperCenter;

		if (tutorial_num != -1) {
			windowRect = GUI.Window(0, new Rect(Screen.width * 0.1f, Screen.height * 0.1f, 
			                                    Screen.width * 0.8f, Screen.height * 0.8f), DoMyWindow, "Instruction");
			Time.timeScale = 0;
		}	
	}
	
	public void DoMyWindow(int windowID) {	
		fireCharacter.GetComponent<Character> ().unmovable = true;
		iceCharacter.GetComponent<Character> ().unmovable = true;
		if (tutorial_num == 0) {
			GUI.Button (new Rect (windowRect.width * 0.5f - 150, windowRect.height * 0.9f - 10, 300, 20), "Press A to Continue");
			GUI.DrawTexture(new Rect(windowRect.width * 0.1f, 10, windowRect.width * 0.8f, windowRect.height * 0.8f), t1, ScaleMode.ScaleToFit, true, 0);
			continueButton();
		} else if (tutorial_num == 1) {
			GUI.Button (new Rect (windowRect.width * 0.5f - 150, windowRect.height * 0.9f - 10, 300, 20), "Press A to Continue");
			GUI.DrawTexture(new Rect(windowRect.width * 0.1f, 10, windowRect.width * 0.8f, windowRect.height * 0.8f), t2, ScaleMode.ScaleToFit, true, 0);
			continueButton();
		}else if (tutorial_num == 2) {
			GUI.Button (new Rect (windowRect.width * 0.5f - 150, windowRect.height * 0.9f - 10, 300, 20), "Press A to Continue");
			GUI.DrawTexture(new Rect(windowRect.width * 0.1f, 10, windowRect.width * 0.8f, windowRect.height * 0.8f), t3, ScaleMode.ScaleToFit, true, 0);
			continueButton();
		}else if (tutorial_num == 3) {
			GUI.Button (new Rect (windowRect.width * 0.5f - 150, windowRect.height * 0.9f - 10, 300, 20), "Press A to Continue");
			GUI.DrawTexture(new Rect(windowRect.width * 0.1f, 10, windowRect.width * 0.8f, windowRect.height * 0.8f), t4, ScaleMode.ScaleToFit, true, 0);
			continueButton();
		}else if (tutorial_num == 4) {
			GUI.Button (new Rect (windowRect.width * 0.5f - 150, windowRect.height * 0.9f - 10, 300, 20), "Press A to Continue");
			GUI.DrawTexture(new Rect(windowRect.width * 0.1f, 10, windowRect.width * 0.8f, windowRect.height * 0.8f), t5, ScaleMode.ScaleToFit, true, 0);
			continueButton();
		}else if (tutorial_num == 5) {
			GUI.Button (new Rect (windowRect.width * 0.5f - 150, windowRect.height * 0.9f - 10, 300, 20), "Press A to Continue");
			GUI.DrawTexture(new Rect(windowRect.width * 0.1f, 10, windowRect.width * 0.8f, windowRect.height * 0.8f), t6, ScaleMode.ScaleToFit, true, 0);
			continueButton();
		}else if (tutorial_num == 6) {
			GUI.Button (new Rect (windowRect.width * 0.5f - 150, windowRect.height * 0.9f - 10, 300, 20), "Press A to Continue");
			GUI.DrawTexture(new Rect(windowRect.width * 0.1f, 10, windowRect.width * 0.8f, windowRect.height * 0.8f), t7, ScaleMode.ScaleToFit, true, 0);
			continueButton();
		}else if (tutorial_num == 7) {
			GUI.Button (new Rect (windowRect.width * 0.5f - 150, windowRect.height * 0.9f - 10, 300, 20), "Press A to Continue");
			GUI.DrawTexture(new Rect(windowRect.width * 0.1f, 10, windowRect.width * 0.8f, windowRect.height * 0.8f), t8, ScaleMode.ScaleToFit, true, 0);
			continueButton();
		}
	}		



	void continueButton() {
		if (control1 != null && control1.Action1){
			tutorial_num = -1;	
			Time.timeScale = 1;
			return;
		}

		if (control2 != null && control2.Action1){
			tutorial_num = -1;	
			Time.timeScale = 1;
			return;
		}
		
		if (control1 == null && Input.GetKeyDown("space")) {
			tutorial_num = -1;	
			Time.timeScale = 1;
		}

		StartCoroutine (setCharacterBack ());
	}

	IEnumerator setCharacterBack(){
		yield return new WaitForSeconds (0.5f);
		fireCharacter.GetComponent<Character> ().unmovable = false;
		iceCharacter.GetComponent<Character> ().unmovable = false;
		yield break;
	}
}
