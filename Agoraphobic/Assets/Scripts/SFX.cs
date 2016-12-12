using UnityEngine;
using System.Collections;

public class SFX : MonoBehaviour {

    public SoundEffectHub effectHub;
    public AudioClip myEffect;
	

    // Use this for initialization
	void Start () {

        effectHub = FindObjectOfType<SoundEffectHub>();

	}
	

    public void PlaySoundEffect()
    {
        if (myEffect) { effectHub.PlayEffect(myEffect); }
        

    }

}
