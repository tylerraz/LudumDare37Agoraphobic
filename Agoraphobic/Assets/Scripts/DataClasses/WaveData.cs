using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu]
public class WaveData : ScriptableObject {

    public string IntroText;
    public string CompletionText;
    public string FailText;

    public SpawnEvent[] SpawnList;
    

}
