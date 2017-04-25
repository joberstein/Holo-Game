using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class CompanionClicked : MonoBehaviour, IInputClickHandler, IHoldHandler, IManipulationHandler {
	public CompanionController controller;
	private Vector3 manipulationPreviousPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnInputClicked(InputEventData eventData) {
		eventData.selectedObject = gameObject;
		controller.clicked (gameObject, getMaterials());
	}

	public void OnHoldStarted(HoldEventData eventData) {
		controller.holdStarted (gameObject, getMaterials ());
	}

	public void OnHoldCompleted(HoldEventData eventData) {
		controller.holdCompleted (gameObject, getMaterials ());
	}

	public void OnHoldCanceled(HoldEventData eventData) {
	}

	public void OnManipulationStarted(ManipulationEventData eventData) {
		eventData.selectedObject = gameObject;
		Vector3 position = eventData.selectedObject.transform.position;
		manipulationPreviousPosition = position;
	}

	public void OnManipulationUpdated(ManipulationEventData eventData) {
		Vector3 moveVector = Vector3.zero;
		Vector3 position = eventData.selectedObject.transform.position;
		moveVector = position - manipulationPreviousPosition;
		manipulationPreviousPosition = position;
		transform.position += moveVector;
	}

	public void OnManipulationCompleted(ManipulationEventData eventData) {
	}

	public void OnManipulationCanceled(ManipulationEventData eventData) {
	}

	private Material[] getMaterials() {
        return controller.getMaterials(gameObject);
	}

    public void Select()
    {
        controller.Select(gameObject);   
    }
}
