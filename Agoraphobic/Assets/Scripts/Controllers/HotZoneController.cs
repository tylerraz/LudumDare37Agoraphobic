using UnityEngine;
using System.Collections;

public class HotZoneController : MonoBehaviour {


    public PlayerController myPlayer;
    public WaveController myWave;
    public SingleHotzone[] Hotzones;

    public float hotZoneMaxhealth;
    public float hotZoneHealPoints;

    public AudioSource hzAudio;


    private void Start()
    {
        foreach (SingleHotzone zone in Hotzones)
        {
            zone.zoneHealth =hotZoneMaxhealth;
        }
        DeactivateHotzones();
    }


    public void ActivateHotzone(int zone)
    {
        Debug.Log("HotzoneActivated" + zone.ToString());

        if (zone<0 || zone>= Hotzones.Length){
            DeactivateHotzones();
            return;

        }

        Hotzones[zone].gameObject.SetActive(true);
        myPlayer.hotzone = Hotzones[zone];

        
    }

    public void DeactivateHotzones() {

        Debug.Log("HotZonesDeactivated");
        foreach (SingleHotzone zone in Hotzones)
        {
            zone.gameObject.SetActive(false);
        }

        myPlayer.hotzone = null;

    }

    public void HotZoneViolated() {

        hzAudio.Play();

    }



}
