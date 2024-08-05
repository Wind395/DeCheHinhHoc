using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class HighScore : MonoBehaviour
{
    public PlayerGameData[] playerGameData;

    [SerializeField] GameObject row;

    [Obsolete]
    private void Start()
    {
        StartCoroutine(GetHighscore());
    }

    // IEnumerator InsertScore()
    // {
    //     for (int i = 0; i < 10; i++)
    //     {
    //         WWWForm form = new WWWForm();
    //         form.AddField("token", PlayerPrefs.GetString("token"));
    //         form.AddField("playerName", playerName[i]);
    //         form.AddField("score", score[i]);
    //         UnityWebRequest www = UnityWebRequest.Post("https://fpl.expvn.com/InsertHighscore.php", form);
    //         yield return www.SendWebRequest();

    //     }            
    // }

    [Obsolete]
    IEnumerator GetHighscore() {
        WWWForm form = new WWWForm();
        form.AddField("token", PlayerPrefs.GetString("token"));
        Debug.Log("Token OK");
        // form.AddField("token", PlayerPrefs.GetString("token"));
        // Debug.Log(PlayerPrefs.GetString("token"));
        // for (int i = 0; i < 10; i++)
        // {
        //     playerName[i] = playerGameData[i].players[i].username;
        //     score[i] = playerGameData[i].players[i].stars;
        //     Debug.Log(playerName[i]);
        //     Debug.Log(score[i]);
        // }
        UnityWebRequest www = UnityWebRequest.Post("https://fpl.expvn.com/GetHighscore.php", form);
        Debug.Log("Post");
        yield return www.SendWebRequest();
        Debug.Log("Sent");

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        } else {
            Debug.Log("Not Bug");
        }

        string response = www.downloadHandler.text;
        if (string.IsNullOrEmpty(response))
        {
            Debug.Log("Response rỗng");
        }
        else
        {
            Debug.Log(response);
        }

        foreach (Transform child in row.transform.parent)
        {
            if (child != row.transform)
            {
                Destroy(child.gameObject);
            }
        }


        string[] lines = response.Split('\n');
        
        //lines = lines.OrderByDescending(line => int.Parse(line.Split('\t')[1])).ToArray();

        foreach (string line in lines)
        {
            string[] columns = line.Split('\t');

            for (int i = 0; i < columns.Length; i++)
            {
                
                //Debug.Log(column);
                var rowInstance = Instantiate(row, row.transform.parent);
                rowInstance.transform.GetChild(0).GetComponent<TMPro.TextMeshProUGUI>().text = (i + 1).ToString();
                rowInstance.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = columns[0];
                rowInstance.transform.GetChild(2).GetComponent<TMPro.TextMeshProUGUI>().text = columns[1];
            }
        }
    }
}
