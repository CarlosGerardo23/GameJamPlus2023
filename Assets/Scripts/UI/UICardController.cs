using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class UICardController : MonoBehaviour, IPointerDownHandler
{
    public Action<CardSO> onPressEvent;
    private Image _image;
    private CardSO _cardSO;

    public CardSO Card => _cardSO;
    public void SetCard(CardSO cardSO)
    {
        _cardSO = cardSO;
        if (_image == null)
            _image = GetComponent<Image>();
        _image.sprite = _cardSO.icon;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log($"press {transform.name}");
        onPressEvent(_cardSO);
    }
}
