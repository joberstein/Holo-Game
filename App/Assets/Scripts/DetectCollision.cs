using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour {
    public CompanionModel model;
    public CompanionView view;

    void OnCollisionEnter(Collision collision)
    {
        // Get companion from collision event.
        GameObject collidedComp = collision.gameObject;
        Debug.Log(collidedComp);
        model.setCanvas(collidedComp.tag);
        int collidedData = model.getCompanion().health;
        model.setHealth(collidedData - 2);
        view.updateHealthBar(collidedComp);
    }
}
