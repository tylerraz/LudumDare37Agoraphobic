using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpeechBubbles : MonoBehaviour {


    public GameObject[] speechBubbles;
    public PlayerController myPlayer;
    public HotZoneController hzRoot;
    public WaveController myWaves;

    public int genericBubble; //set in inspector
    
    

    private GameObject current;
    
    public void CreateSpeechBubble(string s, int speaker)
    {
        current = speechBubbles[speaker];
        
        current.GetComponentInChildren<Text>().text = s;
        current.SetActive(true);
                
    }

    //for intro and completion text
    public void GenericBubble(string gs) {

        CreateSpeechBubble(gs, genericBubble);


    }




}
