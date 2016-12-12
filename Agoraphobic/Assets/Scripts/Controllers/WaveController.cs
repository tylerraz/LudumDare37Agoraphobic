using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class WaveController : MonoBehaviour {



    public WaveData[] GameWaves;

    public PlayerController myPlayer;
    public int waveNumber;
    public int spawnNumber;
    public float timer;
    public Text WaveNumberText;
    public WaveData currentWave;

    //Wave Ready Signalling
    public GameObject ReadyPanel;
    public bool readyClicked;

    public SpeechBubbles mySpeech; //for wave intro and completion text

    public List<GameObject> EnemyArrayList;

    private void Start()
    {
        waveNumber = 0;
        spawnNumber = 0;
        timer = 0;
        readyClicked = false;

        StartCoroutine("SpawnWave");
    }



    private void Update()
    {
        timer += Time.deltaTime;
    }


    public void SetReady() {

        readyClicked = true;
    }


    //WaitUntil Functions for coroutine
    private bool ReadyWave() {

        Time.timeScale = 0;
        if(readyClicked)
        {
            Debug.Log("readyClicked");
            readyClicked = false;
            ReadyPanel.SetActive(false);
            Time.timeScale = 1;
            return true;
        }

        return false;
        
    }

    private bool EnemiesClear()
    {
        if(EnemyArrayList.Count == 0)
        {
            return true;
        }

        return false;

    }


    public void EnemyDied(GameObject enemy) {

        if (EnemyArrayList.Contains(enemy))
        {
            EnemyArrayList.Remove(enemy);

        }
    }



    public IEnumerator SpawnWave() {

        //yield return new WaitForSeconds(1.0f); //waits for everything to initialize. Curse coroutines called by start



        while(waveNumber<GameWaves.Length)
        {
            ReadyPanel.SetActive(true);
            yield return new WaitUntil(ReadyWave);

            currentWave = GameWaves[waveNumber];

            float relativeTime = timer;

            mySpeech.GenericBubble(currentWave.IntroText);
            SetUpWaveObjective((int)currentWave.myObjective);


            while(spawnNumber<currentWave.SpawnList.Length)
            {
                SpawnEvent nextSpawn= currentWave.SpawnList[spawnNumber];

                float resumeLoopTime = relativeTime + nextSpawn.time - timer;

                yield return new WaitForSeconds(resumeLoopTime);

                //after time is up, create the new enemy
                Vector3 entrance = new Vector3(nextSpawn.entrancePoint.position.x, nextSpawn.entrancePoint.position.y, 0.0f);

                GameObject spawn = Instantiate(nextSpawn.SpawnItem, entrance, Quaternion.identity) as GameObject;
                Debug.Log(spawn.layer);

                if (spawn.layer == 11)
                {
                    EnemyArrayList.Add(spawn);
                    spawn.GetComponent<EnemyAI>().playerController = myPlayer;
                }

                spawnNumber++;
                
            }

            yield return new WaitUntil(EnemiesClear);
            mySpeech.GenericBubble(currentWave.CompletionText);
            yield return new WaitForSeconds(2.0f);

            //WaveFinished, Get Ready for Next Wave
            myPlayer.hotzoneRoot.DeactivateHotzones();
            waveNumber++;
            UpdateWaveText();
            spawnNumber = 0;
            
        }

        //All Waves Complete

        yield return new WaitForSeconds(2.0f);
        myPlayer.Victory();

        

    }



    public void SetUpWaveObjective(int i) {

        myPlayer.NewWave(i);
        
        

    }

    private void UpdateWaveText()
    {
        WaveNumberText.text = waveNumber.ToString();


    }


}
