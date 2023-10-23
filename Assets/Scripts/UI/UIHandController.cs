using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
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
    private DeckController _deck;
    private UICardController[] _currentHand = new UICardController[3];
    private UICardController _currentCardSelected;
    bool _isCardSelected;
    private BoardController _boardController;
    private void Awake()
    {
        _deck = FindObjectOfType<DeckController>();
        _boardController = FindObjectOfType<BoardController>();
    }
    IEnumerator Start()
    {
        yield return new WaitForSeconds(2);
        DisplayCard();
    }
    public void OnPress(CardSO cardSO)
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
        _currentCardSelected.SetCard(cardSO);
        _isCardSelected = true;
        _boardController.SetBoard((GemCardSO)_currentCardSelected.Card);

        for (int i = 0; i < _deck.HandOfCards.Length; i++)
        {
            if (_deck.HandOfCards[i] == (GemCardSO)_currentCardSelected.Card)
            {
                _deck.HandOfCards[i] = null;
            }
        }
    }


    public void DisplayCard()
    {
        if (_currentCardSelected != null)
            _currentCardSelected.gameObject.SetActive(false);
        _uiHandHolder.SetActive(true);

        _deck.GetCards();
        for (int i = 0; i < _currentHand.Length; i++)
        {
            if (_currentHand[i] == null)
            {
                _currentHand[i] = Instantiate(_cardHandPrefab);
                _currentHand[i].onPressEvent += OnPress;
            }
            _currentHand[i].transform.SetParent(_handParent);
            _currentHand[i].SetCard(_deck.HandOfCards[i]);
            _currentHand[i].transform.localScale = Vector3.one;
        }
    }
}
