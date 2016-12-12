using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveController : MonoBehaviour {



    public WaveData[] GameWaves;

    public PlayerController myPlayer;
    public int waveNumber;
    public int spawnNumber;
    public float timer;
    public Text WaveNumberText;


    private void Start()
    {
        waveNumber = 0;
        spawnNumber = 0;
        timer = 0;

        StartCoroutine("SpawnWave");
    }



    private void Update()
    {
        timer += Time.deltaTime;
    }



    public IEnumerator SpawnWave() {

        yield return new WaitForSeconds(1.0f); //waits for everything to initialize. Curse coroutines called by start
        while(waveNumber<GameWaves.Length)
        {
            WaveData currentWave = GameWaves[waveNumber];

            float relativeTime = timer;
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
                    spawn.GetComponent<EnemyAI>().playerController = myPlayer;
                }

                spawnNumber++;
                
            }
            //WaveFinished, Get Ready for Next Wave

            waveNumber++;
            spawnNumber = 0;
            yield return new WaitForSeconds(1.0f);
        }



        yield return new WaitForSeconds(1.0f);

    }



    public void SetUpWaveObjective(int i) {

        myPlayer.NewWave(i);
        
        

    }

    private void UpdateWaveText()
    {
        WaveNumberText.text = waveNumber.ToString();


    }


}
