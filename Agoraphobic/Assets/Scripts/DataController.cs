using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;





public class DataController : MonoBehaviour {

    
    public int genderChoice;


    
	void Start () {

        genderChoice = 0;
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("MainMenu");

	}
	
    



}
