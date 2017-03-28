using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionInteractible : Interactible {
	public CompanionController ctrler;

	// Update is called once per frame
	void Update () {
		
	}

	public new void Start() {
		base.Start ();
	}

	protected override void GazeEntered() {
		ctrler.gazeEnterer (gameObject, defaultMaterials);
	}

	protected override void GazeExited() {
		ctrler.gazeExiter (gameObject, defaultMaterials);
	}

	public void Run() {
		ctrler.Run ();
	}

	public void Attack() {
		ctrler.Attack ();
	}

	public void Walk() {
		ctrler.Walk ();
	}


}
