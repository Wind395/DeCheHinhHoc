using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public GameObject[] towers;
    private GameObject currentTowerPosition;

    public void SetTowerPosition(GameObject position)
    {
        currentTowerPosition = position;
    }

    public void BuildTower(int towerIndex)
    {
        if (currentTowerPosition != null && towerIndex >= 0 && towerIndex < towers.Length)
        {
            Instantiate(towers[towerIndex], currentTowerPosition.transform.position, Quaternion.identity);
            currentTowerPosition = null;
        }
    }
}
