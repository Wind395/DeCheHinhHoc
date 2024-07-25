using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HighScore : MonoBehaviour
{
    public PlayerData[] playerData;
    private string[] playerName;
    private int[] score;
    private void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            playerName[i] = playerData[i].username;
            score[i] = playerData[i].stars;
        }
    }
    IEnumerator InsertScore()
    {
        for (int i = 0; i < 10; i++)
        {
            WWWForm form = new WWWForm();
            form.AddField("token", PlayerPrefs.GetString("token"));
            form.AddField("playerName", playerName[i]);
            form.AddField("score", score[i]);
            UnityWebRequest www = UnityWebRequest.Post("https://fpl.expvn.com/InsertHighscore.php", form);
            yield return www.SendWebRequest();

        }            
    }
}
