using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MinionTower : MonoBehaviour
{

    public GameObject[] direc;
    private GameObject[] targetPoints;
    public LayerMask laneLayer;
    public GameObject minions;

    public float radius;

    // Start is called before the first frame update
    void Start()
    {
        RayCastAllDirection();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DistaneCaculator() {
        
    }

    void RayCastAllDirection() {
        RaycastHit2D dirN = Physics2D.Raycast(transform.position, Vector2.up, radius, laneLayer);
        RaycastHit2D dirS = Physics2D.Raycast(transform.position, Vector2.down, radius, laneLayer);
        RaycastHit2D dirW = Physics2D.Raycast(transform.position, Vector2.right, radius, laneLayer);
        RaycastHit2D dirE = Physics2D.Raycast(transform.position, Vector2.left, radius, laneLayer);

        float shortestDistance = Mathf.Infinity;
        string shortestDirection = "";

        if (dirN.collider != null)
        {
            if (dirN.distance < shortestDistance)
            {
                shortestDistance = dirN.distance;
                shortestDirection = "North";
            }
        }

        if (dirS.collider != null)
        {
            if (dirS.distance < shortestDistance)
            {
                shortestDistance = dirS.distance;
                shortestDirection = "South";
            }
        }

        if (dirE.collider != null)
        {
            if (dirE.distance < shortestDistance)
            {
                shortestDistance = dirE.distance;
                shortestDirection = "East";
            }
        }

        if (dirW.collider != null)
        {
            if (dirW.distance < shortestDistance)
            {
                shortestDistance = dirW.distance;
                shortestDirection = "West";
            }
        }

        if (shortestDistance == dirN.distance) {
            direc[0].SetActive(true);

            Transform[] points = direc[0].GetComponentsInChildren<Transform>();
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
                    GameObject minion = Instantiate(minions, transform.position, Quaternion.identity);
                    StartCoroutine(MoveToPosition(minion, targetPoints[i].transform.position));
                }
            } else {
                Debug.Log("Fuck");
            }
        }
        else if (shortestDistance == dirS.distance) {
            direc[1].SetActive(true);

            Transform[] points = direc[1].GetComponentsInChildren<Transform>();
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
                    GameObject minion = Instantiate(minions, transform.position, Quaternion.identity);
                    StartCoroutine(MoveToPosition(minion, targetPoints[i].transform.position));
                }
            }
        }

        else if (shortestDistance == dirW.distance) {
            direc[2].SetActive(true);
            Transform[] points = direc[2].GetComponentsInChildren<Transform>();
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
                    GameObject minion = Instantiate(minions, transform.position, Quaternion.identity);
                    StartCoroutine(MoveToPosition(minion, targetPoints[i].transform.position));
                }
            }
        }

        else if (shortestDistance == dirE.distance) {
            direc[3].SetActive(true);

            Transform[] points = direc[3].GetComponentsInChildren<Transform>();
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
                    GameObject minion = Instantiate(minions, transform.position, Quaternion.identity);
                    StartCoroutine(MoveToPosition(minion, targetPoints[i].transform.position));
                }
            }
        }
    }

    IEnumerator MoveToPosition(GameObject minion, Vector3 target)
    {
        float speed = 1f;
        while (Vector3.Distance(minion.transform.position, target) > 0.1f)
        {
            minion.transform.position = Vector3.MoveTowards(minion.transform.position, target, speed * Time.deltaTime);
            yield return null;
        }
        minion.transform.position = target;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, Vector2.up * radius);
        Gizmos.DrawRay(transform.position, Vector2.down * radius);
        Gizmos.DrawRay(transform.position, Vector2.right * radius);
        Gizmos.DrawRay(transform.position, Vector2.left * radius);
    }
}
