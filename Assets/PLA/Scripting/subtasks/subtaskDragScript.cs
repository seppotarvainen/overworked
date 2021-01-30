using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class subtaskDragScript : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform itemRectTransform;
    private CanvasGroup itemCanvasGroup;
    private Vector3 originalItemAnchor;
    public static bool succeeded = false;

    private void Awake() {
        itemRectTransform = GetComponent<RectTransform>();
        itemCanvasGroup = GetComponent<CanvasGroup>();
        originalItemAnchor = GetComponent<RectTransform>().anchoredPosition;
        itemCanvasGroup.alpha = 1.0f;
        itemCanvasGroup.blocksRaycasts = true;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        itemCanvasGroup.alpha = 0.7f;
        itemCanvasGroup.blocksRaycasts = false;
    }
    
    public void OnDrag(PointerEventData eventData) {
        itemRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    
    public void OnEndDrag(PointerEventData eventData) {
        itemCanvasGroup.alpha = 1.0f;
        itemCanvasGroup.blocksRaycasts = true;
        if (!succeeded)
            GetComponent<RectTransform>().anchoredPosition = originalItemAnchor;
    }
    
    public void OnPointerDown(PointerEventData eventData) {
        Debug.Log("wat");
    }
    
}
