using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropArea : MonoBehaviour, IDropHandler
{

    public GameObject[] buildPlaces;
    public GameObject[] buildPlacesUI;
    
    
    void Awake() {
        SetPlace();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (draggable != null) {
            Card card = draggable.card;
            Destroy(draggable.gameObject);
        }
    }

    public void SetPlace() {
        for (int i = 0; i < buildPlacesUI.Length; i++) {
            buildPlaces[i] = buildPlacesUI[i];
        }
    }
}
