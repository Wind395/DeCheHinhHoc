using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "CardObjects/CardInformation", order = 1)]
public class Card : ScriptableObject
{
    public int cardID;
    public string cardName;
    public int damage;
    public float effect;
    public float radius;
    public float time;
}
