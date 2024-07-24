using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Account : MonoBehaviour
{
    public TMP_InputField usernameField;
    public TMP_InputField mailField;
    public TMP_InputField passwordField;
    public Button loginButton;
    public Button registerButton;

    private string filePath;

    void Start()
    {
        filePath = Application.persistentDataPath + "/suserData.txt";
        Debug.Log("File path: " + filePath);
        loginButton.onClick.AddListener(OnLogin);
        registerButton.onClick.AddListener(OnRegister);
    }

    void OnLogin()
    {
        string username = usernameField.text;
        string password = passwordField.text;

        if (ValidateLogin(username, password))
        {
            Debug.Log("Login successful");
            // Proceed to the next scene or perform other login actions
        }
        else
        {
            Debug.Log("Invalid username or password");
        }
    }

    void OnRegister()
    {
        string username = usernameField.text;
        string mail = mailField.text;
        string password = passwordField.text;

        if (RegisterUser(username, mail, password))
        {
            Debug.Log("Registration successful");
        }
        else
        {
            Debug.Log("User already exists");
        }
    }

    bool ValidateLogin(string username, string password)
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                if (data[0] == username && data[2] == password)
                {
                    return true;
                }
            }
        }
        return false;
    }

    bool RegisterUser(string username, string mail, string password)
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] data = line.Split(',');
                if (data[0] == username)
                {
                    return false; // User already exists
                }
            }
        }

        using (StreamWriter sw = File.AppendText(filePath))
        {
            sw.WriteLine(username + "," + mail + "," + password);
        }
        return true;
    }
}
