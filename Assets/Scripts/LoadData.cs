using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    public string filePath = "Assets/Resources/CardData.txt";
    public List<Card> listCards;

    public void LoadCardData()
    {
        TextAsset loadText = Resources.Load<TextAsset>(filePath);
        string[] lines = loadText.text.Split('\n');

        listCards = new List<Card>();
        for (int i = 1; i < lines.Length; i++)
        {
            string[] col = lines[i].Split('\t');

            Card card = new Card();
            card.cardID = int.Parse(col[0]);
            card.name = col[1];
            card.damage = int.Parse(col[2]);
            card.effect = float.Parse(col[3]);
            card.radius = float.Parse(col[4]);
            card.time = float.Parse(col[5]);

            listCards.Add(card);
        }
    }

    void Start()
    {
        LoadCardData();
    }
}
