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

	public void updateHealthBar(GameObject attackedCompanion) {
        //Debug.Log(attackedCompanion);
        //Debug.Log(attackedCompanion.transform);
		Transform hp = attackedCompanion.transform.FindChild ("HP");
		Transform bar = hp.FindChild ("Bar");
		Transform health = bar.FindChild ("BarOuter");
		Vector3 localScale = health.transform.localScale;
		float dmg = .5f;
		//Debug.Log (localScale.x);

		// constant amount of damage.
		if (localScale.x >= dmg) {
			health.transform.localScale = new Vector3 (localScale.x - dmg, localScale.y, localScale.z);
			TextMesh hpPoints = hp.GetComponentInChildren<TextMesh> ();
			float pointsToFloat = float.Parse (hpPoints.text);
			//pointsToFloat -= CompanionData.MAX_HEALTH * dmg / 20.0f;
			pointsToFloat = 10 * (localScale.x - dmg);
			hpPoints.text = pointsToFloat.ToString ();
		} else {
            // die
            Destroy(attackedCompanion);
		}
	}
}
