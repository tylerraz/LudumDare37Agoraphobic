using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {


    public int genderChoice;
    public DataController myDataController;
    public AudioSource musicAudio;
    public Slider musicSlider;
    public Slider effectsSlider;
    

    private void Start()
    {

        myDataController = FindObjectOfType<DataController>();
        musicAudio = myDataController.GetComponent<AudioSource>();
            

    }

    public void SelectMale() {

        genderChoice = 0;
        StartGame();

    }

    public void SelectFemale()
    {

        genderChoice = 1;
        StartGame();

    }


    public void SelectHelicopter()
    {

        genderChoice = 2;
        StartGame();

    }




    private void StartGame() {


        myDataController.genderChoice = genderChoice;
        SceneManager.LoadScene("GameRoom");

    }
    
    
    public void EffectsVolumeChanged(float f)
    {
        myDataController.effectsVolume = f;
        // AudioListener.volume = f; does not work

    }


    public void MusicVolumeChanged(float f)
    {
        myDataController.musicVolume = f;
        musicAudio.volume= f;

    }

    public void DefaultVolumeSettings() {

        musicSlider.value = .5f;
        effectsSlider.value = .5f;


    }



}
