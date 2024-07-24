using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (draggable != null)
        {
            //ApplyCardEffect(draggable.GetComponent<CardDisplay>().card);
        }
    }

    //private void ApplyCardEffect(Card card)
    //{
    //    // Implement card effect logic here
    //    Debug.Log("Applied card: " + card.cardName);
    //}
}
