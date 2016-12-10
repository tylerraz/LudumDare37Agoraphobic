using UnityEngine;
using System.Collections;

public class HealthPickUp : MonoBehaviour {


    public float healthValue;
    public GameObject otherObject;
    public AudioSource myAudio;


    private void Start()
    {
        myAudio = GetComponent<AudioSource>();

            }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        otherObject = collision.gameObject;


        PlayerHealth PlayerHealth = otherObject.GetComponent<PlayerHealth>();
        PlayerHealth.GainHealth(healthValue);
        myAudio.Play();

        Destroy(gameObject,.25f);


    }

}
