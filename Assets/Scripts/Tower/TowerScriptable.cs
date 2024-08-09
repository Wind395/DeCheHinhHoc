using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "TowerData", menuName = "TowerObjects/TowerInformation")] 
public class TowerScriptable : ScriptableObject
{
    public int TID;
    public GameObject towerPrefab;
    // public int level;
    // public int cost;
    // public int damage;
    // public float range;
    // public float atkSpeed;

    public TextAsset towerDataFile;
    private Dictionary<int, TowerLevelData> towerLevelData = new Dictionary<int, TowerLevelData>();
    private void OnEnable() {
        RegisterTowerScriptable(this);
        LoadTowerData();
    }
    private void LoadTowerData(){
        if(towerDataFile != null){
            string[] lines = towerDataFile.text.Split('\n');
            foreach(string line in lines){
                string[] parts = line.Split('\t');
                if(parts.Length == 5){
                    int level = int.Parse(parts[0]);
                    int damage = int.Parse(parts[1]);
                    float range = float.Parse(parts[2]);
                    float atkSpeed = float.Parse(parts[3]);
                    int cost = int.Parse(parts[4]);
                    TowerLevelData levelData = new TowerLevelData{
                        level = level,
                        damage = damage,
                        range = range,
                        atkSpeed = atkSpeed,
                        cost = cost
                    };
                    towerLevelData[level] = levelData;
                }
            }
        }
    }
    public TowerLevelData GetLevelData(int level){
        if(towerLevelData.TryGetValue(level, out TowerLevelData levelData)){
            return levelData;
        }else{
            return null;
        }
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

[System.Serializable]
public class TowerLevelData
{
    public int level;
    public int damage;
    public float range;
    public float atkSpeed;
    public int cost;
}

