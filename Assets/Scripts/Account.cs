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
    public TextMeshProUGUI message;
    public Button loginButton;
    public Button registerButton;

    void Start()
    {
        loginButton.onClick.AddListener(OnLogin);
        registerButton.onClick.AddListener(OnRegister);
    }

    void OnLogin()
    {
        StartCoroutine(LoginAccount());
        
    }

    void OnRegister()
    {
        StartCoroutine(RegistAccount());
    }

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
                message.text = "Login successfully!\nWait to Login...";
                PlayerPrefs.SetString("token", get);
                Debug.Log(get);
            }
        }
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
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
}
