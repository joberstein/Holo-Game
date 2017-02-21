using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompanionController : MonoBehaviour {
	public CompanionModel model;
	public CompanionView view;

	void Start() {}

	void Update() {}

	public void gazeEnterer(GameObject obj, Material[] mat) {
		model.setCanvas (obj.tag);
		Debug.Log ("gaze entered");
		for (int i = 0; i < mat.Length; i++)
		{
			// 2.d: Uncomment the below line to highlight the material when gaze enters.
			mat[i].SetFloat("_Highlight", .5f);
			mat [i].color = Color.yellow;
			view.changeCompanionText ();
		}
	}

	public void gazeExiter(GameObject obj, Material[] mat) {
		model.setCanvas (obj.tag);
		Debug.Log ("gaze entered");
		for (int i = 0; i < mat.Length; i++) {
			// 2.d: Uncomment the below line to highlight the material when gaze enters.
			mat [i].SetFloat ("_Highlight", 0f);
			mat [i].color = Color.white;
			view.clearCompanionText ();
		}
	}
		
}
