using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour {
    public CompanionController controller;
    public CompanionModel model;
    public CompanionView view;
    private Animation anim;

    void OnCollisionEnter(Collision collision)
    {
        GameObject collidedComp = collision.gameObject;
        
        if (collidedComp.transform.childCount > 0 
            && controller.isCompanion(collidedComp.transform.GetChild(0).gameObject))
        {
            //Debug.Log("Collided");
            //Debug.Log(collidedComp);
            model.setWalk(false);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // Get companion from collision event.
        GameObject collidedComp = collision.gameObject;

        if (collidedComp.transform.childCount > 0
            && controller.isCompanion(collidedComp.transform.GetChild(0).gameObject)
            && collidedComp.transform.GetChild(0).FindChild("Player") == null)
        {
            GameObject child = collidedComp.transform.GetChild(0).gameObject;
            anim = GameObject.Find("Player").GetComponentInParent<Animation>();
            anim.Play(Animations.ATTACK_1);
            AnimationState attack = anim[Animations.ATTACK_1];
            attack.wrapMode = WrapMode.Once;
            // Idle 1 
            // anim.CrossFadeQueued(Animations.IDLE_1);
            //Debug.Log(attack.time == attack.length);
            //Debug.Log(attack.time);
            //Debug.Log(attack.length);
            //if (attack.time == attack.length)
            //{
                model.setCanvas(child.tag);
                int collidedData = model.getCompanion().health;
                model.setHealth(collidedData - 2);
                view.updateHealthBar(collidedComp);
            //}
        }
    }
}
