using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolumeSetter : MonoBehaviour {

    public GameObject settingPanel;
    public AudioSource audioSource;



	// Use this for initialization
	void Start () {
        settingPanel.SetActive(false);

    }


    public void ActivateSettings() {

        settingPanel.SetActive(true);

    }

   public void CloseSettings() {

        settingPanel.SetActive(false);

    }








}
