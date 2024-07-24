using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildPlace : MonoBehaviour
{
    public GameObject SelectUI;
    public SpriteRenderer frame;
    private GameObject Tower;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BuildTowerRanger()
    {
        Tower = BuildManager.instance.SelectedTower();
        GameObject tempTower = Instantiate(Tower, transform.position, Quaternion.identity);
    }

    private void OnMouseDown()
    {
        Instantiate(BuildManager.instance.SelectedTower(), transform.position, Quaternion.identity);
    }

    public void Back()
    {
        SelectUI.SetActive(false);
        frame.enabled = false;
    }
}
