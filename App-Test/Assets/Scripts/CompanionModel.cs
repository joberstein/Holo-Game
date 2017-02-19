using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionModel : MonoBehaviour {
	private int id;
	private string name;
	private string description;
	private string classType;
	private bool isSelected;
	private Dictionary<string, int> humanityPoints;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

	public string getName() {
		return this.name;
	}

	public string getDescription() {
		return this.description;
	}

	public string getClassType() {
		return this.classType;
	}

	public void setCanvas(string tag) {
		
		switch(tag) {
		case "companion1": 
			this.name = "Aether 1";
			this.description = "Hey im hungry";
			this.classType = "FoodEater";
			break;
		case "troll1": 
			this.name = "Troll 1";
			this.description = "Hey im NOT hungry";
			this.classType = "Warrior";
			break;
		case "troll2": 
			this.name = "Troll 2";
			this.description = "Hey im fighting for my life to save my companion";
			this.classType = "Prophet";
			break;
		case "troll3": 
			this.name = "Troll 3";
			this.description = "Nurse joy is the name";
			this.classType = "Healer";
			break;
		case "troll4": 
			this.name = "Troll 4";
			this.description = "jafslksaknska kajsga kfsjaa";
			this.classType = "Ghost";
			break;
		default:
			this.name = "";
			this.description = "";
			this.classType = "";
			break;
		}
	}

}
