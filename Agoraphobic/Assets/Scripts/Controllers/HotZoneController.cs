using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HotZoneController : MonoBehaviour {


    public PlayerController myPlayer;
    public WaveController myWave;
    public SingleHotzone[] Hotzones;

    public Text hotZoneText;
    public Text hotZonePercentText;

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
        UpdateHotZoneText(Hotzones[zone].zoneName);

        
    }

    public void DeactivateHotzones() {

        Debug.Log("HotZonesDeactivated");
        foreach (SingleHotzone zone in Hotzones)
        {
            zone.gameObject.SetActive(false);
        }

        myPlayer.hotzone = null;
        UpdateHotZoneText("None");

    }

    public void HotZoneViolated() {

        hzAudio.Play();

    }

    private void UpdateHotZoneText(string hzName) {
                
        hotZoneText.text = hzName;
        if (hzName == "None") {
            hotZonePercentText.enabled = false;
        }
        
    }

    public void UpdateHotzonePercentage(float percentage) {

        hotZonePercentText.enabled = true;
        hotZonePercentText.text = Mathf.Round(100*percentage).ToString() + "%";

    }


}
