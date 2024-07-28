using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerGame {
    public int UID;
    public int diamonds;
    public string stars;
    public string levels;
    public int cardATK;
    public int cardATKSpeed;
    public int cardRange;
    public int cardHeal;
    public int meteor;
    public int thunderStorm;
    public int Tornado;

}

[CreateAssetMenu(fileName = "Player", menuName = "PlayerObjects/PlayerGameData")]
public class PlayerGameData : ScriptableObject
{
    public PlayerGame[] players;
}
