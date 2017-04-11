using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningController : MonoBehaviour {
	public OpeningModel model;
	public OpeningView view;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void continueTalking() {
		view.changeCaption ();
		Debug.Log ("stuff");
	}
}
