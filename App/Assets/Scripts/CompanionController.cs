using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompanionController : MonoBehaviour {
	public CompanionModel model;
	public CompanionView view;
	private GameObject currComp;

	void Start() {
		currComp = null;
	}

	void Update() {
		changeAnimationState (currComp);
		//Run ();

	}

	public void gazeEnterer(GameObject obj, Material[] mat) {
		model.setCanvas (obj.tag);
		//changeAnimationState (obj);
		currComp = obj;
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
		currComp = null;
		for (int i = 0; i < mat.Length; i++) {
			// 2.d: Uncomment the below line to highlight the material when gaze enters.
			mat [i].SetFloat ("_Highlight", 0f);
			mat [i].color = Color.white;
			view.clearCompanionText ();
		}
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
		if (currComp != null) {
			Animation anim = currComp.GetComponentInParent<Animation> ();
			anim.Play("Run");
			anim["Run"].wrapMode = WrapMode.Once;
			// Idle 1 
			anim.CrossFadeQueued ("Idle_01");
			//Transform t = currComp.GetComponentInParent<Transform>();
			//Debug.Log (t.position);
			//t.position = new Vector3 (t.position.x, t.position.y, t.position.z+=1.0f);
			//t.position.z++
		}
	}

	public void Attack() {
		if (currComp != null) {
			Animation anim = currComp.GetComponentInParent<Animation> ();
			anim.Play("Attack");
			anim["Attack"].wrapMode = WrapMode.Once;
			// Idle 1 
			anim.CrossFadeQueued ("Idle_01");
			//transform.position.x posx = currComp.GetComponentsInParent<Transform>();
		}
	}

	public void Walk() {
		if (currComp != null) {
			Animation anim = currComp.GetComponentInParent<Animation> ();
			anim.Play("Walk");
			anim["Walk"].wrapMode = WrapMode.Once;
			// Idle 1 
			anim.CrossFadeQueued ("Idle_01");
			//transform.position.x posx = currComp.GetComponentsInParent<Transform>();
		}
	}

	// Attack
	// Walk
	// Die
	// Idle 1

}
