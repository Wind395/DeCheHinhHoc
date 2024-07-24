using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{

    public GameObject cardPrefab;
    public Transform handArea;
    public Card[] cards;

    
    void Start()
    {
        foreach (Card card in cards)
        {
            GameObject cardGo = Instantiate(cardPrefab, handArea);

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
