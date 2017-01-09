using UnityEngine;
using System.Collections;
using InControl;

public class start_scene : MonoBehaviour {
	
	public Rect windowRect = new Rect(0, 0, 0, 0);
	private GUIStyle style0;
	private int count = 0;
	public Texture t1;
	public Texture t2;
	public Texture t3;
	private int timer = 0;
	
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
		if (timer > 0) {
			timer--;
		}

		if (InputManager.Devices.Count == 1) {
			control1 = InputManager.Devices[0];
		}
		else if (InputManager.Devices.Count == 2) {
			control1 = InputManager.Devices[0];
			control2 = InputManager.Devices[1];
		}
	
		if (timer == 0) {
			if (control1 != null && control2 != null) {
				if (control1.DPadDown || control2.DPadDown) {
					count++;
					if (count > 2) {
						count = 0;
					}
				} else if (control1.DPadUp || control2.DPadUp) {
					count--;
					if (count < 0) {
						count = 2;
					}
				}	
				timer = 15;
			}		
		}

		windowRect = GUI.Window(0, new Rect(0, 0, 
		                                    Screen.width, Screen.height), DoMyWindow, "");
	}		

	public void DoMyWindow(int windowID) {	
		if (count == 0) {
			GUI.DrawTexture(new Rect(0, 0, windowRect.width, windowRect.height), t1, ScaleMode.ScaleToFit, true, 0);
			if (control1.Action1 || control2.Action1) {
				Application.LoadLevel("Instruction_Scene");
			}
		} else if (count == 1) {
			GUI.DrawTexture(new Rect(0, 0, windowRect.width, windowRect.height), t2, ScaleMode.ScaleToFit, true, 0);
			if (control1.Action1 || control2.Action1 || Input.GetKeyDown(KeyCode.A)) {
				Application.LoadLevel("Level1");
			}
		} else if (count == 2) {
			GUI.DrawTexture(new Rect(0, 0, windowRect.width, windowRect.height), t3, ScaleMode.ScaleToFit, true, 0);
		}	
	}
}