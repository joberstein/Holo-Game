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
		monologue.Add("Hello, my name is Jared Mwitu");
		monologue.Add ("I have devoted my life to the study of AI and biomechanical organisms");
		monologue.Add ("At Exoai we focused on developing synergy between sapience and sentience");
		monologue.Add ("We have developed 5 prototype machs and need users to help perfect them");
		monologue.Add ("Are you interested in learning more and helping with our research?");
		monologue.Add ("I will elaborate more on myself soon. Before that, allow me to show you our machs");
		monologue.Add ("Select the one that you are most interested in conducting tests with");
		monologue.Add ("");
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
