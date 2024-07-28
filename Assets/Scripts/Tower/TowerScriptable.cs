using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "TowerData", menuName = "TowerObjects/TowerInformation")] 
public class TowerScriptable : ScriptableObject
{
    public int TID;
    public GameObject towerPrefab;
    public int level;
    public int cost;
    public int damage;
    public float range;
    public float atkSpeed;


    private void OnEnable() {
        RegisterTowerScriptable(this);
    }


    private static Dictionary<int, TowerScriptable> towerScriptables = new Dictionary<int, TowerScriptable>();
    

    // Set TID = towerIndex to know what tower we want buy
    public static void RegisterTowerScriptable(TowerScriptable towerScriptable)
    {
        towerScriptables[towerScriptable.TID] = towerScriptable;
    }

    public static TowerScriptable GetTowerScriptable(int towerIndex)
    {
        if (towerScriptables.TryGetValue(towerIndex, out TowerScriptable towerScriptable))
        {
            return towerScriptable;
        }
        else
        {
            Debug.LogError("Không tìm thấy TowerScriptable với TID " + towerIndex);
            return null;
        }
    }
}

