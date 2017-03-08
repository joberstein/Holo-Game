using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpeningModel : MonoBehaviour {
	private List<string> monologue;
	private AudioClip[] sounds;

	// Use this for initialization
	void Start () {
		monologue = new List<string> ();
		loadMonologue ();
		loadSounds ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void loadMonologue() {
		monologue.Add("Curl into a furry donut present belly, scratch when stroked.");
		monologue.Add ("Spot something, big eyes, big eyes, crouch, shake butt, prepare to pounce");
		monologue.Add ("Attack feet chew foot");
	}

	private void loadSounds(){
		sounds = Resources.LoadAll<AudioClip> ("Sounds/OpeningMonologue");
	}

	public AudioClip[] getSounds() {
		AudioClip[] clone = sounds;
		return clone;
	}

	/** Gets the monologue */
	public List<string> getMonologue() {
		List<string> clone = monologue;
		return clone;
	}
}
