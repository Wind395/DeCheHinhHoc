using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    public WaveManager waveManager;
    public TextMeshProUGUI currentWave;
    public GameObject pauseMenu;
    private void Start()
    {
        currentWave.text = "Wave 1/10";
    }
    private void Update()
    {
        if (waveManager.currentWave == waveManager.totalWavesInCurrentMap)
        {
            currentWave.text = "Final wave";
        }
        else
        {
            currentWave.text = $"Wave {waveManager.currentWave + 1}/10";
        }
    }

    public void Pause() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void X2() {
        Time.timeScale = 2f;
    }

    public void PlayAgain() {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
    }

    public void ExitToMenu() {
        SceneManager.LoadScene(1);
    }
    
}
