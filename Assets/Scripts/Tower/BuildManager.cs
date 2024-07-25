using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Call TowerManager to get BuildTower method
    public TowerManager towerManager;
    public BuildPlace buildPlace;

    // After clicked button, tower will build (Get towerIndex from button's variable)
    public void OnTowerButtonClicked(int towerIndex)
    {
        towerManager.BuildTower(towerIndex);
        gameObject.SetActive(false);
        buildPlace.frame.enabled = false;
    }
}
