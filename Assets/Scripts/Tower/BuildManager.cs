using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public TowerManager towerManager;
    public BuildPlace buildPlace;
    public void OnTowerButtonClicked(int towerIndex)
    {
        towerManager.BuildTower(towerIndex);
        gameObject.SetActive(false);
        buildPlace.frame.enabled = false;
    }
}
