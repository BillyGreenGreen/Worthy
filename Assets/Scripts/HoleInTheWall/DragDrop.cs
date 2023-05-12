using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] public Canvas canvas;
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Transform oldTransform;
    private Transform oldParent;
    private void Awake(){
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1);
    }
    public void OnBeginDrag(PointerEventData eventData){
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = .6f;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
    }

    public void OnEndDrag(PointerEventData eventData){
        canvasGroup.enabled = true;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        gameObject.transform.position = new Vector3(oldTransform.position.x, oldTransform.position.y, -1);
        gameObject.transform.SetParent(oldParent);
        gameObject.transform.SetAsFirstSibling();
        Debug.Log("END DRAG");
    }

    public void OnDrag(PointerEventData eventData){
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnPointerDown(PointerEventData eventData){
        Debug.Log("OnPointerDown");

        oldTransform = gameObject.transform;
        oldParent = gameObject.transform.parent;
    }
}
