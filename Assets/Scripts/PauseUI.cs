using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{

    public GameObject pauseMenu;
    
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
    }

    public void ExitToMenu() {
        SceneManager.LoadScene(1);
    }
    
}
