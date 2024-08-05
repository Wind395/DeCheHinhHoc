using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "CardObjects/CardInformation", order = 1)]
public class Card : ScriptableObject
{
    public int CID;
    public enum CardTypes {ATK, ATKSpeed, Range, Heal, Tornado, Thunder, Meteor};
    public CardTypes cardType;
    public string cardName;
    public int damage;
    public float effect;
    public float radius;
    public float time;
}

