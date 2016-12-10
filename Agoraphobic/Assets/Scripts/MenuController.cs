using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour {


    public int genderChoice;
    public DataController myDataController;

    private void Start()
    {

        myDataController = FindObjectOfType<DataController>();

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
    
    




}
