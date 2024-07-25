using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerData", menuName = "TowerObjects/TowerInformation")] 
public class TowerScriptable : ScriptableObject
{
    public GameObject towerPrefab;
    public int level;
    public int cost;
    public int damage;
    public float range;
    public float atkSpeed;
}

