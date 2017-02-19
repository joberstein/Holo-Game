using UnityEngine;

/// <summary>
/// The Interactible class flags a Game Object as being "Interactible".
/// Determines what happens when an Interactible is being gazed at.
/// </summary>
public abstract class Interactible : MonoBehaviour
{
    [Tooltip("Audio clip to play when interacting with this hologram.")]
    public AudioClip TargetFeedbackSound;
    private AudioSource audioSource;
    protected Material[] defaultMaterials;

    protected virtual void Start()
    {
        defaultMaterials = GetComponent<Renderer>().materials;

        // Add a BoxCollider if the interactible does not contain one.
        Collider collider = GetComponentInChildren<Collider>();
        if (collider == null)
        {
            gameObject.AddComponent<BoxCollider>();
        }

        EnableAudioHapticFeedback();
    }

    private void EnableAudioHapticFeedback()
    {
        // If this hologram has an audio clip, add an AudioSource with this clip.
        if (TargetFeedbackSound != null)
        {
            audioSource = GetComponent<AudioSource>();
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }

            audioSource.clip = TargetFeedbackSound;
            audioSource.playOnAwake = false;
            audioSource.spatialBlend = 1;
            audioSource.dopplerLevel = 0;
        }
    }

    /* TODO: DEVELOPER CODING EXERCISE 2.d */

	protected abstract void GazeEntered();
    //{
        //for (int i = 0; i < defaultMaterials.Length; i++)
        //{
            // 2.d: Uncomment the below line to highlight the material when gaze enters.
            // defaultMaterials[i].SetFloat("_Highlight", .5f);
			// defaultMaterials [i].color = Color.yellow;
			// companion.changeCompanionText ();
        //}
    //}

	protected abstract void GazeExited();
    //{
      //  for (int i = 0; i < defaultMaterials.Length; i++)
        //{
            // 2.d: Uncomment the below line to remove highlight on material when gaze exits.
          //  defaultMaterials[i].SetFloat("_Highlight", 0f);
			//defaultMaterials [i].color = Color.white;
			//companion.clearCompanionText ();
        //}
    //}

    void OnSelect()
    {
        for (int i = 0; i < defaultMaterials.Length; i++)
        {
            defaultMaterials[i].SetFloat("_Highlight", .5f);
        }

        // Play the audioSource feedback when we gaze and select a hologram.
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }

        /* TODO: DEVELOPER CODING EXERCISE 6.a */
        // 6.a: Handle the OnSelect by sending a PerformTagAlong message.
		SendMessage("PerformTagAlong");
    }
}