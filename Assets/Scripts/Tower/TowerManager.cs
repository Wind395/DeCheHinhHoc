using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{
    public TowerScriptable[] towers;
    private GameObject currentTowerPosition;
    public GameObject SelectUI;
    public BuildPlace buildPlace;

    // Set Position for Tower after click to Build Place (In Build Place)
    public void SetTowerPosition(GameObject position)
    {
        // Current Position has been update from OnMouseDown from BuildPlace script
        currentTowerPosition = position;
    }

    // Use index to build towers (Get index from button UI)
    public void BuildTower(int towerIndex)
    {
        if (currentTowerPosition != null && towerIndex >= 0 && towerIndex < towers.Length)
        {
            GameObject tower = Instantiate(towers[towerIndex].towerPrefab, currentTowerPosition.transform.position, Quaternion.identity);
            Tower towerInfo = tower.GetComponent<Tower>();
            towerInfo.SetStats(towers[towerIndex]);
            SelectUI.SetActive(false);
            buildPlace.frame.enabled = false;
            // Reset Position after Build Tower at that place
            currentTowerPosition = null;
        }    
    }

    // Active Back Button Outside
    public void Back() {
        SelectUI.SetActive(false);
        buildPlace.frame.enabled = false;
        currentTowerPosition = null;
    }
}
