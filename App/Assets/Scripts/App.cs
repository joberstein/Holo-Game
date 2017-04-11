using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class App : MonoBehaviour {
	public CompanionModel model;
	public CompanionView view;
	public CompanionController controller;
    public List<string> scenes;
    private static  int currentScene = 0;

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
    void Start ()
    {
        scenes.Add("Opening");
        scenes.Add("Beginning-Test");
        scenes.Add("Battle");

    }
	
	// Update is called once per frame
	void Update () {
	}

    public void changeScenes()
    {
        Debug.Log(currentScene);
        if (currentScene >= scenes.Count-1)
        {
            currentScene = 0;
        } else
        {
            currentScene++;
        }
        SceneManager.LoadScene(scenes[currentScene]);
        Debug.Log(currentScene);
    }
}
