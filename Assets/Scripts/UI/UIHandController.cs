using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIHandController : MonoBehaviour
{
    [SerializeField] private UICardController _cardHandPrefab;
    [SerializeField] private GameObject _cardOnHandPrefab;
    [SerializeField] private GameObject _uiHandHolder;
    [SerializeField] private Transform _handParent;
    [SerializeField] private Transform _cardSelctedParent;
    [SerializeField] private PlayerDataSO _playerData;
    private List<UICardController> _currentHand = new List<UICardController>();
    private UICardController _currentCardSelected;
    bool _isCardSelected;
    private BoardManager _boardManager;
    private void Awake()
    {
        _boardManager = FindObjectOfType<BoardManager>();
    }
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        DisplayCard();
    }
    public void OnPress(UICardController card)
    {
        _uiHandHolder.SetActive(false);
        Vector3 pos = Vector3.zero;
        if (_currentCardSelected == null)
        {
            _currentCardSelected = Instantiate(_cardOnHandPrefab, pos, Quaternion.identity, _cardSelctedParent).GetComponent<UICardController>();
            _currentCardSelected.transform.localScale = Vector3.one;
            _currentCardSelected.transform.localPosition = Vector3.zero;
        }
        _currentCardSelected.gameObject.SetActive(true);
        _currentCardSelected.SetCard(card.Card);
        _isCardSelected = true;
        _boardManager.SetGemCardOnBoard();
        _playerData.cardSelected = card;
    }


    public void DisplayCard()
    {
        if (_currentCardSelected != null)
            _currentCardSelected.gameObject.SetActive(false);
        _uiHandHolder.SetActive(true);
        for (int i = 0; i < _playerData.cardsInHand.Count; i++)
        {
            if (_currentHand.Count < _playerData.cardsInHand.Count || _currentHand[i] == null)
            {
                UICardController cardUI = Instantiate(_cardHandPrefab);
                cardUI.transform.SetParent(_handParent);
                _currentHand.Add(cardUI);
                _currentHand[i].onPressEvent += OnPress;
                _currentHand[i].onFinishBoard += RemoveFromHand;
            }
            _currentHand[i].SetCard(_playerData.cardsInHand[i]);
            _currentHand[i].transform.localScale = Vector3.one;
        }
    }
    public void SetCardsVisualsState(bool state)
    {
        _uiHandHolder.SetActive(state);
        _currentCardSelected?.SetVisualsState(!state);
    }
    public void RemoveFromHand(UICardController cardToRemove)
    {
        _currentHand.Remove(cardToRemove);
        Destroy(cardToRemove.gameObject);
    }

}
