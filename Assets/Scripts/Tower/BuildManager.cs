using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    public static BuildManager instance;

    // Call TowerManager to get BuildTower method
    public TowerManager towerManager;
    public BuildPlace buildPlace;
    public TowerScriptable towerScriptable;


    void Awake() {
        if (instance != null & instance != this) {
            Destroy(gameObject);
        }
        else {
            instance = this;
        }
    }

    // After clicked button, tower will build (Get towerIndex from button's variable)
    public void OnTowerButtonClicked(int towerIndex)
    {
        towerScriptable = TowerScriptable.GetTowerScriptable(towerIndex);
        TowerLevelData levelData = towerScriptable.GetLevelData(1);
        if (LevelManager.instance.golds >= levelData.cost) {
            LevelManager.instance.RemoveGold(levelData.cost);
            towerManager.BuildTower(towerIndex);
            gameObject.SetActive(false);
            buildPlace.frame.enabled = false;
        } else {
            Debug.Log("Not enough gold");
        }
    }
}
