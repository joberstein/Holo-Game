﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompanionController : MonoBehaviour {
	public CompanionModel model;
	//private static Animations animations;
	public CompanionView view;
	private GameObject currComp;
	private Animation anim;
    private CompanionData companion;

	void Start() {
		currComp = null;
		anim = null;
	}

	void Update() {
		changeAnimationState (currComp);
        companion = this.model.getCompanion();

		// Move 'isWalking' variable to model. 
		if (companion.walkState) {
			Debug.Log ("Current Companion: " + currComp.transform.parent.name);
			AnimationState walking = anim [Animations.WALK];
			if (walking.time < walking.length && walking.time != 0) {
				Transform parentTransform = currComp.transform.parent;
				// Space.World = walk in direction facing
				// Camera.main.transform = walk towards camera
				parentTransform.Translate (Vector3.back * Time.deltaTime, Camera.main.transform);
				currComp.transform.SetParent (parentTransform);
			} else {
				model.setWalk(false);
			}
		}
	}

	public void gazeEntered(GameObject obj, Material[] mat) {
		model.setCanvas (obj.tag);
		//changeAnimationState (obj);
		currComp = obj;
		anim = currComp.GetComponentInParent<Animation> ();
		for (int i = 0; i < mat.Length; i++) {
			// 2.d: Uncomment the below line to highlight the material when gaze enters.
			mat[i].SetFloat("_Highlight", .5f);
			mat [i].color = Color.yellow;
			view.changeCompanionText ();
		}
	}

	public void gazeExited(GameObject obj, Material[] mat) {
		model.setCanvas (obj.tag);
		for (int i = 0; i < mat.Length; i++) {
			// 2.d: Uncomment the below line to highlight the material when gaze enters.
			mat [i].SetFloat ("_Highlight", 0f);
			mat [i].color = Color.white;
			view.clearCompanionText ();
		}
	}

	public void clicked(GameObject obj, Material[] mat) {
		model.setCanvas (obj.tag);
		currComp = null;
		for (int i = 0; i < mat.Length; i++) {
			mat [i].color = Color.red;
		}
	}

	public void holdStarted(GameObject obj, Material[] mat) {
		model.setCanvas (obj.tag);
		currComp = null;
		for (int i = 0; i < mat.Length; i++) {
			mat [i].color = Color.green;
		}
	}

	public void holdCompleted(GameObject obj, Material[] mat) {
		gazeExited (obj, mat);
	}
		
	public void changeAnimationState(GameObject obj) {

		if (Input.GetKeyDown ("b") && currComp != null) {
			Animation anim = obj.GetComponentInParent<Animation> ();
			ArrayList animations = new ArrayList();
			foreach (AnimationState state in anim) {
				animations.Add (state);
				Debug.Log(state.name);
			}
		}
	}

	public void Run() {
		if (currComp != null && !currComp.tag.Equals("companion1")) {
			Animation anim = currComp.GetComponentInParent<Animation> ();
			anim.Play(Animations.RUN);
			anim[Animations.RUN].wrapMode = WrapMode.Once;
			// Idle 1 
			anim.CrossFadeQueued (Animations.IDLE_1);
			//Transform t = currComp.GetComponentInParent<Transform>();
			//Debug.Log (t.position);
			//t.position = new Vector3 (t.position.x, t.position.y, t.position.z+=1.0f);
			//t.position.z++
		}
	}

	public void Attack() {
		if (currComp != null && !currComp.tag.Equals("companion1")) {
			anim = currComp.GetComponentInParent<Animation> ();
			Debug.Log (anim);
			anim.Play(Animations.ATTACK_1);
			anim[Animations.ATTACK_1].wrapMode = WrapMode.Once;
			// Idle 1 
			anim.CrossFadeQueued (Animations.IDLE_1);
			//transform.position.x posx = currComp.GetComponentsInParent<Transform>();
		}
	}

	public void Walk() {
		if (currComp != null && !currComp.tag.Equals ("companion1")) {
			AnimationState walking = anim [Animations.WALK];
			Transform parentTransform = currComp.transform.parent;

			model.setWalk(true);
			anim.Play (Animations.WALK);
			walking.wrapMode = WrapMode.Once;
			anim.CrossFadeQueued (Animations.IDLE_1);
		}
	}
}
