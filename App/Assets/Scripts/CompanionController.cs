using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompanionController : MonoBehaviour {
	public CompanionModel model;
	public CompanionView view;
	private GameObject gazeComp;
    private GameObject selectComp;
	private Animation anim;
    private CompanionData companion;
    private HashSet<string> companions;
	private HashSet<string> customCompanions;

	void Start() {
		gazeComp = null;
        anim = GameObject.Find("Player").transform.parent.GetComponentInParent<Animation>();
		customCompanions = new HashSet<string> ();
		customCompanions.Add ("aether");
		customCompanions.Add ("purple");

        companions = new HashSet<string>();
        companions.Add("aether");
        companions.Add("purple");
        companions.Add("troll1");
        companions.Add("troll2");
        companions.Add("troll3");
	}

	void Update() {
		// changeAnimationState (gazeComp);
        companion = this.model.getCompanion();

		// Move 'isWalking' variable to model. 
		if (companion.walkState) {
			// Debug.Log ("Current Companion: " + selectComp.transform.parent.name);
			AnimationState walking = anim [Animations.WALK];
			if (walking.time != 0) {//walking.time < walking.length && walking.time != 0) {
                //Transform parentTransform = currComp.transform.parent;
                Transform parentTransform = GameObject.Find("Player").transform.parent.parent;
                // Space.World = walk in direction facing
                // Camera.main.transform = walk towards camera
                // parentTransform.Translate (Vector3.back * Time.deltaTime, Camera.main.transform);
                //parentTransform.Translate(Vector3.back * Time.deltaTime, selectComp.transform);
                // Debug.Log(parentTransform.position);
                // Debug.Log(selectComp.transform.position);
                parentTransform.position = Vector3.MoveTowards(parentTransform.position, selectComp.transform.position, 1*Time.deltaTime);
                //parentTransform.rotation = Quaternion.LookRotation(parentTransform.position);
                parentTransform.forward = parentTransform.position;
                // currComp.transform.SetParent (parentTransform);
            } else {
				//model.setWalk(false);
			}
		}
	}

	public void gazeEntered(GameObject obj, Material[] mat) {
		// model.setCanvas (obj.tag);
		//changeAnimationState (obj);
		gazeComp = obj;
		//anim = gazeComp.GetComponentInParent<Animation> ();
		for (int i = 0; i < mat.Length; i++) {
			// 2.d: Uncomment the below line to highlight the material when gaze enters.
			mat[i].SetFloat("_Highlight", .5f);
			mat [i].color = Color.yellow;
			view.changeCompanionText ();
		}
	}

	public void gazeExited(GameObject obj, Material[] mat) {
		// model.setCanvas (obj.tag);
		for (int i = 0; i < mat.Length; i++) {
			// 2.d: Uncomment the below line to highlight the material when gaze enters.
			mat [i].SetFloat ("_Highlight", 0f);
			mat [i].color = Color.white;
			view.clearCompanionText ();
		}
	}

	public void clicked(GameObject obj, Material[] mat) {
        selectComp = obj;
        // model.setCanvas(obj.tag);
        
		for (int i = 0; i < mat.Length; i++) {
			mat [i].color = Color.red;
		}
	}



	public void holdStarted(GameObject obj, Material[] mat) {
		// model.setCanvas (obj.tag);
		selectComp = null;
		for (int i = 0; i < mat.Length; i++) {
			mat [i].color = Color.green;
		}
	}

	public void holdCompleted(GameObject obj, Material[] mat) {
		gazeExited (obj, mat);
	}
		
	public void changeAnimationState(GameObject obj) {
		if (Input.GetKeyDown ("b") && gazeComp != null) {
			Animation anim = obj.GetComponentInParent<Animation> ();
			ArrayList animations = new ArrayList();
			foreach (AnimationState state in anim) {
				animations.Add (state);
				// Debug.Log(state.name);
			}
		}
	}

    public void Select(GameObject obj)
    {
        if (this.isCompanion(gazeComp))
        {
            this.clicked(gazeComp, this.getMaterials(gazeComp));
        }
    }

	public void Run() {
		if (!this.isCustomCompanion()) {
			//Animation anim = gazeComp.GetComponentInParent<Animation> ();
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
        if (this.isCompanion(selectComp))
        {
            Rigidbody rbSelected = selectComp.transform.parent.GetComponent<Rigidbody>();
            Rigidbody rbPlayer = GameObject.Find("Player").transform.parent.parent.GetComponent<Rigidbody>();
            rbSelected.isKinematic = false;
            rbPlayer.isKinematic = false;
            anim.Play(Animations.WALK);
            anim[Animations.WALK].wrapMode = WrapMode.Loop;
            Debug.Log(GameObject.Find("Player").transform.parent.gameObject.tag);
            model.setCanvas(GameObject.Find("Player").transform.parent.gameObject.tag);
            model.setWalk(true);

            // Idle 1 
            //anim.CrossFadeQueued(Animations.IDLE_1);
        }
	}

    public void Walk() {
		if (!this.isCustomCompanion()) {
			AnimationState walking = anim [Animations.WALK];
			model.setWalk(true);
			anim.Play (Animations.WALK);
			walking.wrapMode = WrapMode.Once;
			anim.CrossFadeQueued (Animations.IDLE_1);
		}
	}

	public bool isCustomCompanion() {
		return gazeComp != null && customCompanions.Contains (gazeComp.tag);
	}

    public bool isCompanion(GameObject obj)
    {
        return (obj != null) && companions.Contains(obj.tag);
    }

    public Material[] getMaterials(GameObject obj)
    {
        return view.getCompanionMaterials(obj);
    }
}
