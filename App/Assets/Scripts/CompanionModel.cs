using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionData
{
	public static readonly int MAX_HEALTH = 200;

    public CompanionData () {
    }

    public CompanionData(string name, string description, string classType)
    {
        this.name = name;
        this.description = description;
        this.classType = classType;
		this.health = MAX_HEALTH;
		this.walkState = false;
		this.isSelected = false;
		this.humanityPoints = new Dictionary<string, int> ();
    }

    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string classType { get; set; }
	public int health { get; set; }
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
        c1 = new CompanionData("Aether", "Lurks in the shadows waiting for the right time to strike an opponent.", "Assassain");
        c2 = new CompanionData("Purple", "It's magic tentacles can instantly cure any injuries and replenish stamina.", "Healer");
        c3 = new CompanionData("Igor", "Conjures enchantments and hexes to support allies and deter enemies.", "Sorcerer");
        c4 = new CompanionData("Sora", "Utilizes the power of the sun and light to vanquish foes.", "Paladin");
        c5 = new CompanionData("Arnold", "Wields strong weaponary and fights with the strength of 1000 soliders.", "Warrior");
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

	public void setHealth(int pts) 
	{
		pts = Mathf.Min(CompanionData.MAX_HEALTH, pts);
		pts = Mathf.Max(0, pts);
		this.companion.health = pts;
	}
}
