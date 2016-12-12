using UnityEngine;
using System.Collections;

public class HealthPickUp : MonoBehaviour {


    public float healthValue;
    public GameObject otherObject;
    public SFX mySound;


    private void Start()
    {
        mySound = GetComponent<SFX>();

            }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        otherObject = collision.gameObject;


        PlayerHealth PlayerHealth = otherObject.GetComponent<PlayerHealth>();
        PlayerHealth.GainHealth(healthValue);
        mySound.PlaySoundEffect();

        Destroy(gameObject,.25f);


    }

}
