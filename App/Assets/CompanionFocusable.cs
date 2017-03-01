using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class CompanionFocusable : MonoBehaviour, IFocusable {
	public CompanionController controller;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnFocusEnter() {
		controller.gazeEntered (gameObject, getMaterials());
	}

	public void OnFocusExit() {
		controller.gazeExited (gameObject, getMaterials());
	}

	public void Run() {
		controller.Run ();
	}

	public void Attack() {
		controller.Attack ();
	}

	public void Walk() {
		controller.Walk ();
	}

	private Material[] getMaterials() {
		return controller.view.getCompanionMaterials (gameObject);
	}
}
