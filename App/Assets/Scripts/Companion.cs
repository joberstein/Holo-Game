using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Companion : MonoBehaviour {
	public int id;
	public string name;
	public string description;
	public string classType;
	public bool isSelected;
	public Dictionary<string, int> humanityPoints;

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
				textObj.text = "Name:\n" + this.name;
				break;
			case "Description":
				textObj.text = "Description:\n" + this.description;
				break;
			case "Class":
				textObj.text = "Class:\n" + this.classType;
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
				textObj.text = "";
				break;
			case "Description":
				textObj.text = "";
				break;
			case "Class":
				textObj.text = "";
				break;
			default:
				break;
			}
		}
	}
}
