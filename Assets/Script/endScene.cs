using UnityEngine;
using System.Collections;
using InControl;

public class endScene : MonoBehaviour {
	
	public Rect windowRect = new Rect(0, 0, 0, 0);
	private GUIStyle style0;
	private int count = 0;
	public Texture t1;
	
	private InputDevice control1;
	private InputDevice control2;
	
	void Start () {
		if (InputManager.Devices.Count == 1) {
			control1 = InputManager.Devices[0];
		}
		else if (InputManager.Devices.Count == 2) {
			control1 = InputManager.Devices[0];
			control2 = InputManager.Devices[1];
		}
	}
	
	void OnGUI() {
		style0 = new GUIStyle (GUI.skin.textField);
		style0.fontSize = 50;
		style0.normal.textColor = Color.red;
		style0.alignment = TextAnchor.UpperCenter;
		
		windowRect = GUI.Window(0, new Rect(0, 0, 
		                                    Screen.width, Screen.height), DoMyWindow, "Ice & Fire");
	}
	
	public void DoMyWindow(int windowID) {	
		GUI.Button (new Rect (windowRect.width * 0.5f - 150, windowRect.height * 0.9f - 10, 300, 20), "restart");
		continueButton ();
	}
	
	void continueButton() {

		if (control1 != null && control1.Action1){
			Application.LoadLevel("Level1");
		}	
		if (control2 != null && control2.Action1){
			Application.LoadLevel("Level1");
		}
	}
}