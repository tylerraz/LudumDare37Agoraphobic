using UnityEngine;
using System.Collections;

public class SoundEffectHub : MonoBehaviour {

    public DataController myData;
    private AudioSource myAudio;

    public float volume = .5f;
    
    // Use this for initialization
	void Start () {


        myData = FindObjectOfType<DataController>();
        myAudio = gameObject.GetComponent<AudioSource>();

        if (myData) { myAudio.volume = myData.effectsVolume; } else
        {
            myAudio.volume = volume;

        }
        

	}


    public void PlayEffect(AudioClip effectClip) {

        myAudio.clip = effectClip;
        myAudio.Play();

    }



}
