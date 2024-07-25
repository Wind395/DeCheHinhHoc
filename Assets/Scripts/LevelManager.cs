using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Transform startPoint;
    public Transform[] path;

    public WaveManager waveManager;
    public GameObject enemyPrefab;
    public float spawnInterval = 0.3f;
    public int enemyPerWave = 3;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        FirstWave();
    }
    public void FirstWave()
    {
        StartCoroutine(SpawnEnemies());
    }
    public void StartNextWave()
    {
        waveManager.StartNextWave();
        enemyPerWave++;
        StartCoroutine(SpawnEnemies());
    }
    private IEnumerator SpawnEnemies()
    {
        EnemyLevel enemyLevel = waveManager.GetEnemyForWave();

        for (int i = 0; i < enemyPerWave; i++)
        {
            GameObject enemyObj = Instantiate(enemyPrefab, startPoint.position, Quaternion.identity);
            Enemy enemy = enemyObj.GetComponent<Enemy>();
            enemy.Initialize(enemyLevel);
            enemy.SetPath(path);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
