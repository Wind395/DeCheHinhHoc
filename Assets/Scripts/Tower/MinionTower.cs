using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class MinionTower : MonoBehaviour
{

    public GameObject[] direc;
    private GameObject[] targetPoints;
    private GameObject targetDirection = null;
    Transform[] points;
    public LayerMask laneLayer;
    public GameObject unit;



    RaycastHit2D dirN;
    RaycastHit2D dirS;
    RaycastHit2D dirW;
    RaycastHit2D dirE;

    float shortestDistance = Mathf.Infinity;

    public float radius;


    // Start is called before the first frame update
    void Start()
    {
        All();

    }

    // Update is called once per frame
    void Update()
    {
        
    }



    void All() {

        dirN = Physics2D.Raycast(transform.position, Vector2.up, radius, laneLayer);
        dirS = Physics2D.Raycast(transform.position, Vector2.down, radius, laneLayer);
        dirW = Physics2D.Raycast(transform.position, Vector2.right, radius, laneLayer);
        dirE = Physics2D.Raycast(transform.position, Vector2.left, radius, laneLayer);


        if (dirN.collider != null)
        {
            if (dirN.distance < shortestDistance)
            {
                shortestDistance = dirN.distance;
                targetDirection = direc[0];
            }
        }

        if (dirS.collider != null)
        {
            if (dirS.distance < shortestDistance)
            {
                shortestDistance = dirS.distance;
                targetDirection = direc[1];
            }
        }

        if (dirW.collider != null)
        {
            if (dirW.distance < shortestDistance)
            {
                shortestDistance = dirW.distance;
                targetDirection = direc[2];
            }
        }

        if (dirE.collider != null)
        {
            if (dirE.distance < shortestDistance)
            {
                shortestDistance = dirE.distance;
                targetDirection = direc[3];
            }
        }


        if (targetDirection != null) {
            targetDirection.SetActive(true);
            Transform[] points = targetDirection.GetComponentsInChildren<Transform>();
            targetPoints = new GameObject[3];

            int j = 0;
            for (int i = 0; i < points.Length; i++) {
                if (j < 3) {
                    targetPoints[j] = points[i].gameObject;
                    j++;
                } else {
                    break;
                }
            }
            if (targetPoints.Length == 3) {
            for (int i = 0; i < 3; i++) {
                GameObject minion = Instantiate(unit, transform.position, Quaternion.identity);
                StartCoroutine(MoveToPosition(minion, targetPoints[i].transform.position));
                }
            }
        }
    }

    IEnumerator MoveToPosition(GameObject minion, Vector3 target)
    {
        float speed = 1f;
            while (minion != null && Vector3.Distance(minion.transform.position, target) > 0.1f)
            {
                if (minion == null) yield break;
                minion.transform.position = Vector3.MoveTowards(minion.transform.position, target, speed * Time.deltaTime);
                yield return null;
            }
            if (minion != null) minion.transform.position = target;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, Vector2.up * radius);
        Gizmos.DrawRay(transform.position, Vector2.down * radius);
        Gizmos.DrawRay(transform.position, Vector2.right * radius);
        Gizmos.DrawRay(transform.position, Vector2.left * radius);
    }
}
