using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class MapWaveData
{
    public string mapName;
    public int totalWaves;
}

[CreateAssetMenu(fileName = "WaveData", menuName = "WaveScriptable/WaveData", order = 1)]
public class WaveScriptable : ScriptableObject
{
    public MapWaveData[] maps;
}
