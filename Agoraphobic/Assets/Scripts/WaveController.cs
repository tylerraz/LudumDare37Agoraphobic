using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour {



    public WaveData[] GameWaves;

    public int waveNumber;
    public int spawnNumber;
    public float timer;

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

        while(waveNumber<GameWaves.Length)
        {
            WaveData currentWave = GameWaves[waveNumber];

            float relativeTime = timer;

            while(spawnNumber<currentWave.SpawnList.Length)
            {
                SpawnEvent nextSpawn= currentWave.SpawnList[spawnNumber];

                float resumeLoopTime = relativeTime + nextSpawn.time - timer;

                yield return new WaitForSeconds(resumeLoopTime);

                //after time is up, create the new enemy
                Vector3 entrance = new Vector3(nextSpawn.entrancePoint.position.x, nextSpawn.entrancePoint.position.y, 0.0f);

                GameObject Enemy = Instantiate(nextSpawn.SpawnItem, entrance, Quaternion.identity) as GameObject;

                spawnNumber++;
                
            }
            //WaveFinished, Get Ready for Next Wave

            waveNumber++;
            spawnNumber = 0;
            yield return new WaitForSeconds(1.0f);
        }



        yield return new WaitForSeconds(1.0f);

    }






}
