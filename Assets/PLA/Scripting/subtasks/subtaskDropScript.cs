using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class subtaskDropScript : MonoBehaviour, IDropHandler
{
    [SerializeField] private subtaskDragScript dragscript;

    public void OnDrop(PointerEventData eventData) {
        Debug.Log("OnDrop");
        if (eventData.pointerDrag != null) {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            dragscript.succeeded = true;
        }
    }
}
