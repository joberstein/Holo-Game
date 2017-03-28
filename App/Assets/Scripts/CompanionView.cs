using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompanionView : MonoBehaviour {
	public CompanionModel model;
	private Canvas canvas;
	private Text[] texts;
    private CompanionData companion;

	// Use this for initialization
	void Start () {
		canvas = GameObject.Find ("Canvas").GetComponent<Canvas>();
		texts = canvas.GetComponentsInChildren<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void changeCompanionText()
    {
        companion = this.model.getCompanion();
        foreach (Text textObj in texts) {
			switch(textObj.gameObject.name) 
			{
			case "Name":
				textObj.text = "Name:\n" + companion.name;
				break;
			case "Description":
				textObj.text = "Description:\n" + companion.description;
				break;
			case "Class":
				textObj.text = "Class:\n" + companion.classType;
				break;
			default:
				break;
			}
		}
	}

	public void clearCompanionText() {
		foreach (Text textObj in texts) {
			switch(textObj.gameObject.name) 
			{
			case "Name":
			case "Description":
			case "Class":
				textObj.text = "";
				break;
			default:
				break;
			}
		}
	}

	public Material[] getCompanionMaterials(GameObject obj) {
		return obj.GetComponent<Renderer>().materials;
	}
}
