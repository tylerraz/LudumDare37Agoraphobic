using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;





public class DataController : MonoBehaviour {

    
    public int genderChoice;
    public float musicVolume;
    public float effectsVolume;

    
	void Start () {

        genderChoice = 0;
        musicVolume = .5f;
        effectsVolume = .5f;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("MainMenu");

	}
	
    



}
