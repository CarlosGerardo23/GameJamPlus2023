using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class UICardController : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private UnityEvent _onPress;
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
        _onPress.Invoke();
        Debug.Log($"press {transform.name}");
        onPressEvent(_cardSO);
    }
}
