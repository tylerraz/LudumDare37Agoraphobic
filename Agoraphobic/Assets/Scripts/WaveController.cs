using UnityEngine;
using System.Collections;

public class WaveController : MonoBehaviour {



    public WaveData[] GameWaves;

    public int waveNumber;
    public int enemyNumber;
    public float timer;

    private void Start()
    {
        waveNumber = 0;
        enemyNumber = 0;
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

            while(enemyNumber<currentWave.SpawnList.Length)
            {
                SpawnEvent nextEnemy= currentWave.SpawnList[enemyNumber];

                float resumeLoopTime = relativeTime + nextEnemy.time - timer;

                yield return new WaitForSeconds(resumeLoopTime);

                //after time is up, create the new enemy
                Vector3 entrance = new Vector3(nextEnemy.entrancePoint.position.x, nextEnemy.entrancePoint.position.y, 0.0f);

                GameObject Enemy = Instantiate(nextEnemy.SpawnItem, entrance, Quaternion.identity) as GameObject;

                enemyNumber++;
                
            }

            waveNumber++;
            yield return new WaitForSeconds(1.0f);
        }



        yield return new WaitForSeconds(1.0f);

    }






}
