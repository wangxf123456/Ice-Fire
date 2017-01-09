using UnityEngine;
using System.Collections;
using InControl;

public class Instruction_scene : MonoBehaviour {

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
		if (count == 0) {
			//		GUI.DrawTexture(new Rect(windowRect.width * 0.1f, 10, windowRect.width * 0.8f, windowRect.height * 0.8f), t1, ScaleMode.ScaleToFit, true, 0);
			GUI.Button (new Rect (windowRect.width * 0.5f - 150, windowRect.height * 0.8f - 10, 300, 20), "Start");

			GUI.Button (new Rect (windowRect.width * 0.5f - 150, windowRect.height * 0.9f - 10, 300, 20), "Instruction");
		} else if (count == 1) {
			//		GUI.DrawTexture(new Rect(windowRect.width * 0.1f, 10, windowRect.width * 0.8f, windowRect.height * 0.8f), t1, ScaleMode.ScaleToFit, true, 0);
			GUI.Button (new Rect (windowRect.width * 0.5f - 150, windowRect.height * 0.9f - 10, 300, 20), "Back");			
		}
		continueButton ();
	}

	void continueButton() {
		if (count == 0) {
			if (control1 != null && control1.Action1){
				Application.LoadLevel("Level1");
			}	
			if (control2 != null && control2.Action1){
				Application.LoadLevel("Level1");
			}
			if (control1 != null && control1.Action2){
				count = 1;
			}	
			if (control2 != null && control2.Action2){
				count = 1;
			}
		} else if (count == 1) {
			if (control1 != null && control1.Action2){
				count = 0;
			}	
			if (control2 != null && control2.Action2){
				count = 0;
			}		
		}
	}
}