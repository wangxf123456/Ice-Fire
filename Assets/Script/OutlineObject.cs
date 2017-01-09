using UnityEngine;
using System.Collections;

public class OutlineObject : MonoBehaviour {

	public bool isOutlined = false;
	public GameObject target;
	Material[] glowMaterials;
	Shader originShader;
	Shader glowShader;

	// Use this for initialization
	void Start () {
		glowMaterials = GetComponent<Renderer>().materials;
		originShader = glowMaterials[0].shader;
		glowShader = Shader.Find("Custom/GlowShader");
	}
	
	// Update is called once per frame
	void Update () {
	    if (isOutlined) {
			glowMaterials[0].shader = glowShader;
			GetComponent<Renderer>().materials = glowMaterials;
		}
		else {
			glowMaterials[0].shader = originShader;
			GetComponent<Renderer>().materials = glowMaterials;
		}

	}
}
