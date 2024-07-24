using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlace : MonoBehaviour
{
    public GameObject SelectUI;
    public SpriteRenderer frame;
    public TowerManager towerManager;

    private void OnMouseDown()
    {
        towerManager.SetTowerPosition(gameObject);
        SelectUI.SetActive(true);
        frame.enabled = true;
    }
}
