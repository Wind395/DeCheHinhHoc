using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour, IDropHandler
{

    public void OnDrop(PointerEventData eventData)
    {
        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (draggable != null) {
            Card card = draggable.card;
            Destroy(draggable.gameObject);
            Debug.Log("Destroyed");
            // RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(eventData.position), Vector2.zero);
            // Debug.Log(hit);
            // if (hit.collider != null && hit.collider.CompareTag("Tower")) {
            //     Debug.Log("Hit tower");
            //     NormalBowTower normalBowTower = hit.collider.GetComponent<NormalBowTower>();
            //     if (normalBowTower != null) {
            //         normalBowTower.ApplyCard(card);
            //         Debug.Log("Apply Done!");
            //     }
            // }

            // switch(card.CID) {
            //     case 1:
            //         Debug.Log("ATK");
            //         break;
            //     case 2:
            //         Debug.Log("ATKSpeed");
            //         break;
            //     case 3:
            //         Debug.Log("Range");
            //         break;
            // }
        }
    }
}
