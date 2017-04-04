using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionData
{

    public CompanionData () {
    }

    public CompanionData(string name, string description, string classType)
    {
        this.name = name;
        this.description = description;
        this.classType = classType;
		this.walkState = false;
		this.isSelected = false;
		this.humanityPoints = new Dictionary<string, int> ();
    }

    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string classType { get; set; }
    public bool isSelected { get; set; }
    public Dictionary<string, int> humanityPoints { get; set; }
    public bool walkState { get; set; }
}

public class CompanionModel : MonoBehaviour {
    private CompanionData companion;
    private CompanionData c1;
    private CompanionData c2;
    private CompanionData c3;
    private CompanionData c4;
    private CompanionData c5;

    // Use this for initialization
    void Start ()
    {
        c1 = new CompanionData("Aether", "Hey im hungry", "FoodEater");
        c2 = new CompanionData("Purple", "I am yo fashha", "Tentacular");
        c3 = new CompanionData("Jesse", "I'm such a troll", "Rock");
        c4 = new CompanionData("Ari", "I will be pirate king", "Pirate Captain");
        c5 = new CompanionData("Muigai", "Old black lady", "Sandwitch");
    }
	
	// Update is called once per frame
	void Update () {
	}

    public CompanionData getCompanion()
    {
		return this.companion == null ? new CompanionData() : this.companion;
    }

	public void setCanvas(string tag)
    {	
		switch(tag) {
		case "aether":
            companion = c1;
			break;
		case "purple":
            companion = c2;
            break;
		case "troll1":
            companion = c3;
            break;
		case "troll2":
            companion = c4;
            break;
		case "troll3":
            companion = c5;
            break;
		default:
            companion = new CompanionData();
			break;
		}
    }

    public void setWalk(bool state)
    {
        this.companion.walkState = state;
    }

}
