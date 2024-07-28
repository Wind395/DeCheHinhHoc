using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public Transform startPoint;
    public Transform[] path;
    public int homeHealth = 20;
    public TextMeshProUGUI homehealthText;
    public GameObject skipWave;

    public WaveManager waveManager;
    public GameObject enemyPrefab;
    public GameObject WinUI;
    public GameObject LoseUI;
    public GameObject IngameUI;
    public float spawnInterval = 0.3f;
    public int enemyPerWave = 3;
    public float waveCD = 0;

    public int golds;
    public TextMeshProUGUI goldText;

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
        waveManager.GameWinEvent += OnGameWin;
        FirstWave();
        golds = 400;
    }

    private void Update()
    {

        homehealthText.text = homeHealth.ToString();

        // Wave System
        waveCD += Time.deltaTime;
        if(skipWave != null && waveCD >= (enemyPerWave * 2) / 3)
        {
            skipWave.SetActive(true);
        }
        if(waveCD >= enemyPerWave * 2)
        {
            StartNextWave();
        }

        // Gold System
        UpdateGold();
    }

    public void GameOver() {
        Time.timeScale = 0f;
        Debug.Log("You Lose!");
        LoseUI.SetActive(true);
    }


    // ----------------------- Gold System ----------------------------//
    public void AddGold(int amount) {
        golds += amount;
    }

    public void RemoveGold(int amount) {
        golds -= amount;
    }

    public void UpdateGold() {
        goldText.text = golds.ToString();
    }
    //-----------------------------------------------------------------//
    

    //------------------------Wave System------------------------------//
    public void FirstWave()
    {
        waveManager.enemiesRemaining = enemyPerWave;
        StartCoroutine(SpawnEnemies());
    }
    public void StartNextWave()
    {
        waveManager.StartNextWave();
        enemyPerWave++;
        waveManager.enemiesRemaining += enemyPerWave;
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
    //-----------------------------------------------------------------//


    private void OnGameWin(){
        Time.timeScale = 0;
        IngameUI.SetActive(false);
        WinUI.SetActive(true);
    }

    public void ReStart(){
        SceneManager.LoadScene("1");
        Time.timeScale = 1;
    }
    public void Home(){
        SceneManager.LoadScene("Menu");
        Time.timeScale = 1;
    }
    public void NextLvl(){

    }
}
