using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompanionView : MonoBehaviour {
	public CompanionModel model;
	private Canvas canvas;
	private Text[] texts;

	// Use this for initialization
	void Start () {
		canvas = GameObject.Find ("Canvas").GetComponent<Canvas>();
		texts = canvas.GetComponentsInChildren<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void changeCompanionText() {
		foreach (Text textObj in texts) {
			switch(textObj.gameObject.name) 
			{
			case "Name":
				textObj.text = "Name:\n" + this.model.getName();
				break;
			case "Description":
				textObj.text = "Description:\n" + this.model.getDescription();
				break;
			case "Class":
				textObj.text = "Class:\n" + this.model.getClassType();
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

}
