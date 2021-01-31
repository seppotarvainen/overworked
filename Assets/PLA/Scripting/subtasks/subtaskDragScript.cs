using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class subtaskDragScript : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject textinfo;
    [SerializeField] private soundController soundcontrol;

    private RectTransform itemRectTransform;
    private CanvasGroup itemCanvasGroup;
    private Vector3 originalItemAnchor;
    public bool succeeded;

    private void Awake() {
        itemRectTransform = GetComponent<RectTransform>();
        itemCanvasGroup = GetComponent<CanvasGroup>();
        originalItemAnchor = GetComponent<RectTransform>().anchoredPosition;
        itemCanvasGroup.alpha = 1.0f;
        itemCanvasGroup.blocksRaycasts = true;
    }

    public void OnBeginDrag(PointerEventData eventData) {
        if (!succeeded)
        {
            itemCanvasGroup.alpha = 0.7f;
            itemCanvasGroup.blocksRaycasts = false;
        }
    }
    
    public void OnDrag(PointerEventData eventData) {
        if (!succeeded)
        {
            itemRectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }
    
    public void OnEndDrag(PointerEventData eventData) {
        itemCanvasGroup.alpha = 1.0f;
        itemCanvasGroup.blocksRaycasts = true;
        if (!succeeded)
        {
            GetComponent<RectTransform>().anchoredPosition = originalItemAnchor;
        }
    }

    void FixedUpdate()
    {
        if (succeeded)
        {
            textinfo.SetActive(true);
        }
    }

}
