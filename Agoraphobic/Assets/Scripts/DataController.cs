using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;





public class DataController : MonoBehaviour {

	
    
    // Use this for initialization
	void Start () {

        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("MainMenu");

	}
	




}
