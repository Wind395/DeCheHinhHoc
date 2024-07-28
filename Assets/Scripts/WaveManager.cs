using UnityEngine;
using System.Linq;
using System.Collections;

[System.Serializable]
public class MapWaveData
{
    public string mapName;
    public int totalWaves;
}

[CreateAssetMenu(fileName = "WaveData", menuName = "ScriptableObjects/WaveData", order = 1)]
public class WaveData : ScriptableObject
{
    public MapWaveData[] maps;
}

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;
    public EnemyScriptable enemyData;
    public WaveData waveData;
    public string currentMapName;

    public int currentWave { get; private set; } = 0;
    public int totalWavesInCurrentMap { get; private set; } = 0;
    public int enemiesRemaining = 0;

    public delegate void OnWaveComplete();
    public event OnWaveComplete WaveCompleteEvent;

    public delegate void OnGameWin();
    public event OnGameWin GameWinEvent;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
        }
    }

    void Start()
    {
        MapWaveData currentMap = waveData.maps.FirstOrDefault(map => map.mapName == currentMapName);
        if (currentMap.mapName != null)
        {
            totalWavesInCurrentMap = currentMap.totalWaves;
        }
        else
        {
            Debug.LogError("Map not found in WaveData");
        }
    }

    public void StartNextWave()
    {
        if (currentWave < totalWavesInCurrentMap)
        {
            currentWave++;
        }
        else
        {
            Debug.Log("All waves completed for the current map.");
            if(GameWinEvent != null){
                GameWinEvent.Invoke();
            }
        }
    }

    public EnemyLevel GetEnemyForWave()
    {
        int enemyLevelIndex = Mathf.Min(currentWave, enemyData.levels.Length - 1);
        return enemyData.levels[enemyLevelIndex];
    }

    public void EnemyDestroyed()
    {
        enemiesRemaining--;
        if(enemiesRemaining <= 0){
            if(currentWave >= totalWavesInCurrentMap){
                if(GameWinEvent != null){
                    GameWinEvent.Invoke();
                }
            }else{
                if(WaveCompleteEvent != null){
                    WaveCompleteEvent.Invoke();
                }
            }
        }
    }
}
