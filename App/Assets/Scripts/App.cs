using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour {
	public CompanionModel model;
	public CompanionView view;
	public CompanionController controller;

	public Dictionary<string, MonoBehaviour> ugh;
	// TODO Abstract the shit out of this
//	public enum Pairings {Help , Me };
//	public Pairings stuff;
//
//	[System.Serializable]
//	public struct MVC {
//		public string MVCtype;
//	}

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}
}
