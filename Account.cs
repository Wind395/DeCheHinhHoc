using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class Account : MonoBehaviour
{
    public TMP_InputField usernameField;
    public TMP_InputField passwordField;
    public TMP_InputField playerNameField;
    public TextMeshProUGUI message;
    public Button loginButton;
    public Button registerButton;

    [System.Obsolete]
    void Start()
    {
        loginButton.onClick.AddListener(OnLogin);
        registerButton.onClick.AddListener(OnRegister);
    }

    [System.Obsolete]
    void OnLogin()
    {
        StartCoroutine(LoginAccount());
    }

    void OnRegister()
    {
        StartCoroutine(RegistAccount());
    }

    [System.Obsolete]
    IEnumerator LoginAccount()
    {
        WWWForm form = new WWWForm();
        form.AddField("user", usernameField.text);
        form.AddField("passwd", passwordField.text);
        UnityWebRequest www = UnityWebRequest.Post("https://fpl.expvn.com/dangnhap.php", form);
        yield return www.SendWebRequest();

        if (!www.isDone)
        {
            message.text = "Connection failed";
        }
        else
        {
            string get = www.downloadHandler.text;
            if (get == "empty")
            {
                message.text = "Data fields cannot be left blank!";
            }
            else if (get == "" || get == null)
            {
                message.text = "Username or password is incorrect!";
            }
            else if (get.Contains("Lỗi"))
            {
                message.text = "Connection failed!";
            }
            else
            {
                if(playerNameField.text == "")
                {
                    message.text = "WHAT IS YOUR NAME?";                    
                }
                else
                {
                    message.text = "Login successfully!\nWait to Login...";
                    PlayerPrefs.SetString("token", get);
                    PlayerPrefs.SetString("name", playerNameField.text);
                    Debug.Log(get);
                    Debug.Log(playerNameField);
                    yield return new WaitForSeconds(2);
                    //StartCoroutine(GetHighscore());
                    SceneManager.LoadScene(1);
                }
            }
        }        
    }

    IEnumerator RegistAccount()
    {
        WWWForm form = new WWWForm();
        form.AddField("user", usernameField.text);
        form.AddField("passwd", passwordField.text);
        UnityWebRequest www = UnityWebRequest.Post("https://fpl.expvn.com/dangky.php", form);
        yield return www.SendWebRequest();

        if (!www.isDone)
        {
            message.text = "Connection failed";
        }
        else
        {
            string get = www.downloadHandler.text;
            switch (get)
            {
                case "exist": message.text = "Account already exists!"; break;
                case "OK": message.text = "Registration successfully!"; break;
                case "ERROR": message.text = "Registration failed!"; break;
                default: message.text = "Connection failed!"; break;
            }
        }
    }

    // IEnumerator GetHighscore() {
    //     WWWForm form = new WWWForm();
    //     form.AddField("token", PlayerPrefs.GetString("token"));
    //     Debug.Log("Token OK");
    //     // form.AddField("token", PlayerPrefs.GetString("token"));
    //     // Debug.Log(PlayerPrefs.GetString("token"));
    //     // for (int i = 0; i < 10; i++)
    //     // {
    //     //     playerName[i] = playerGameData[i].players[i].username;
    //     //     score[i] = playerGameData[i].players[i].stars;
    //     //     Debug.Log(playerName[i]);
    //     //     Debug.Log(score[i]);
    //     // }
    //     UnityWebRequest www = UnityWebRequest.Post("https://fpl.expvn.com/GetHighscore.php", form);
    //     yield return www.SendWebRequest();

    //     string response = www.downloadHandler.text;
    //     Debug.Log(response);

    //     // Split the response string into lines
    //     string[] lines = response.Split('\n');

    //     // Iterate over each line
    //     foreach (string line in lines)
    //     {
    //         // Split each line into columns using the tab character
    //         string[] columns = line.Split('\t');

    //         // Iterate over each column
    //         foreach (string column in columns)
    //         {
    //             Debug.Log(column);
    //         }
    //     }
    // }
}
