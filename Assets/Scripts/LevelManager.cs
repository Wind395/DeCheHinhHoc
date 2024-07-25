using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Transform startPoint;
    public Transform[] path;
    public GameObject skipWave;

    public WaveManager waveManager;
    public GameObject enemyPrefab;
    public float spawnInterval = 0.3f;
    public int enemyPerWave = 3;
    public float waveCD = 0;

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

    private void Update()
    {
        waveCD += Time.deltaTime;
        if(waveCD >= (enemyPerWave * 2) / 3)
        {
            skipWave.SetActive(true);
        }
        if(waveCD >= enemyPerWave * 2)
        {
            StartNextWave();
        }
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
        skipWave.SetActive(false);
        waveCD = 0;
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
