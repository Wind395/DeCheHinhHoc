using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RandomHighScoreGenerator : MonoBehaviour
{
    public TextMeshProUGUI[] rankText;
    public TextMeshProUGUI[] nameText;
    public TextMeshProUGUI[] levelText;
    public PlayerData playerData;
    //private string[] randomNames = { "AAA", "BBB", "CCC", "DDD", "EEE" };

    void Start()
    {
        GenerateRandomHighScores();
    }

    void GenerateRandomHighScores()
    {
        for (int i = 0; i < 10; i++)
        {
            int randomRank = i + 1; // Rank từ 1 đến 10
            string name = playerData.username;
            int randomLevel = Random.Range(1, 51); // Level ngẫu nhiên từ 1 đến 50

            rankText[i].text = randomRank.ToString();
            nameText[i].text = name;
            levelText[i].text = randomLevel.ToString();
        }
    }
}