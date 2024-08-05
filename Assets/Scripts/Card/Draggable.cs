using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;


public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    
    private Vector2 startPosition;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    public Canvas canvas;

    public DropArea dropArea;

    public Card card;
    


    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.5f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        Debug.Log("End Drag");

        // Kiểm tra xem thẻ bài có được thả vào tower hay không
        if (eventData.pointerCurrentRaycast.gameObject.CompareTag("Tower")) {
            // Áp dụng buff cho tower
            NormalBowTower tower = eventData.pointerCurrentRaycast.gameObject.GetComponent<NormalBowTower>();
            tower.ApplyCard(card);
        } else {
            // Trả lại thẻ bài về vị trí ban đầu
            transform.position = startPosition;
        }

        // if (!gameObject.IsDestroyed()) {
        //     transform.position = startPosition;
        // }
    }

    // private void OnTriggerEnter2D(Collider2D other) {
    //     if(other.gameObject.CompareTag("Tower")) {
    //         NormalBowTower tower = other.gameObject.GetComponent<NormalBowTower>();
    //         Debug.Log("Trigged1");
    //         tower.ApplyCard(card);
    //         Debug.Log("Trigged2");
    //     }
    // }
}
