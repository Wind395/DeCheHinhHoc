using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[System.Serializable]
public class PlayerGame {
    public int UID;
    public string username;
    public int diamonds;
    public int stars;
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
