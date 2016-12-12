using UnityEngine;
using System.Collections;

public class HotZoneController : MonoBehaviour {


    public PlayerController myPlayer;
    public WaveController myWave;
    public GameObject[] Hotzones;

    public float hotZoneMaxhealth;
    public float hotZoneHealPoints;

    public AudioSource hzAudio;


    private void Start()
    {
        foreach (GameObject zone in Hotzones)
        {
            zone.GetComponent<SingleHotzone>().zoneHealth =hotZoneMaxhealth;
        }
        DeactivateHotzones();
    }


    public void ActivateHotzone(int zone)
    {
        if(zone<0 || zone>= Hotzones.Length){
            DeactivateHotzones();
            return;

        }

        Hotzones[zone].SetActive(true);
        myPlayer.hotzone = Hotzones[zone];

        
    }

    public void DeactivateHotzones() {

        foreach (GameObject zone in Hotzones)
        {
            zone.SetActive(false);
        }

        myPlayer.hotzone = null;

    }

    public void HotZoneViolated() {

        hzAudio.Play();

    }



}
