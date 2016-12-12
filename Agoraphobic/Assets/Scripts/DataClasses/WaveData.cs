using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu]
public class WaveData : ScriptableObject {

    public enum WaveObjective { Survive, Hotzone1, Hotzone2, Hotzone3, Hotzone4, Hotzone5 }

    public string IntroText;
    public string CompletionText;
    public string FailText;

    public WaveObjective myObjective;
    

    public SpawnEvent[] SpawnList;
    

}
