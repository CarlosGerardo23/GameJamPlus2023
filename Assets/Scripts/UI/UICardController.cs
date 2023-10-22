using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class UICardController : MonoBehaviour, IPointerDownHandler
{
    public Action onPressEvent;
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log($"press {transform.name}");
        onPressEvent();
    }
}
