using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {
    public int UID;
    public string username;
    public string email;
    public string password;
    public int stars;
}

[CreateAssetMenu(fileName = "Player", menuName = "PlayerObjects/PlayersData", order = 1)]
public class PlayerScriptable : ScriptableObject
{
    public PlayerData[] players;
    
}


