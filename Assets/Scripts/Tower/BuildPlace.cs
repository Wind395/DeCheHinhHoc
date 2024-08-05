using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlace : MonoBehaviour
{
    public GameObject SelectUI;
    public GameObject CardUI;
    public SpriteRenderer frame;
    public TowerManager towerManager;


    void Update() {
        
    }

    // After Clicked
    private void OnMouseDown()
    {
        // Send postion from this object to towerManager to Set Position
        towerManager.SetTowerPosition(gameObject);
        SelectUI.SetActive(true);
        CardUI.SetActive(false);
        frame.enabled = true;
    }
}
