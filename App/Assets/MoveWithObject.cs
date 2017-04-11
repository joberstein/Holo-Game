using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithObject : MonoBehaviour {
	public GameObject objectToMoveWith;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 objectToMoveWithPosition = objectToMoveWith.transform.position;
		this.transform.position.Set(
			objectToMoveWithPosition.x,
			objectToMoveWithPosition.y + 5,
			objectToMoveWithPosition.z
		);
	}
}
