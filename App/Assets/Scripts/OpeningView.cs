﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpeningView : MonoBehaviour {
	public OpeningModel model;
	private Canvas canvas;
	private AudioSource audioSrc;
	private Text[] texts;
	private int itr;

	// Use this for initialization
	void Start () {
		//monologue = model.getMonologue ();
		itr = 0;
		Debug.Log ( model.getMonologue () [0].ToString() );
		Debug.Log ("no");
		canvas = GameObject.Find ("Canvas").GetComponent<Canvas>();
		texts = canvas.GetComponentsInChildren<Text> ();
		audioSrc = GameObject.Find ("Narrator").GetComponent<AudioSource> ();
		changeCaption ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void changeCaption() {
		Text caption = texts [0].GetComponent<Text>();
		caption.text = model.getMonologue () [itr].ToString();
		audioSrc.clip = model.getSounds () [itr];
		audioSrc.Play ();
		itr++;
		if (itr > model.getMonologue ().Count - 1) {
			SceneManager.LoadScene ("Beginning-Test");
		}
	}
}
