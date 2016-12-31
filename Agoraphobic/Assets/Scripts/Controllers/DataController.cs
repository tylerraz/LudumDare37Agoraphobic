using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;





public class DataController : MonoBehaviour {

    
    public int genderChoice;
    public float musicVolume;
    public float effectsVolume;

    private static bool created = false;
    
	void Start () {

        if(created)
        { Destroy(gameObject); }

        genderChoice = 0;
        musicVolume = .5f;
        effectsVolume = .5f;
        DontDestroyOnLoad(gameObject);

        created = true;

	}
	
    



}
