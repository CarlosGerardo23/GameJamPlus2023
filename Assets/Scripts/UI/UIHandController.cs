using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class UIHandController : MonoBehaviour, IDragHandler, IDropHandler
{
    [SerializeField] private UICardController _cardHandPrefab;
    [SerializeField] private GameObject _cardOnHandPrefab;
    [SerializeField] private GameObject _uiHandHolder;
    [SerializeField] private Transform _handParent;
    private DeckController _deck;
    private UICardController[] _currentHand = new UICardController[5];
    private GameObject _currentCardSelected;
    bool _isCardSelected;

    private Vector3 _offset;
    private void Awake()
    {
        _deck = FindObjectOfType<DeckController>();
    }
    void Start()
    {
        DisplayCard();
    }
    public void OnPress()
    {
        _uiHandHolder.SetActive(false);
        Vector3 pos = Vector3.zero;
        _currentCardSelected = Instantiate(_cardOnHandPrefab, pos, Quaternion.identity);
        _isCardSelected = true;
    }

    public void OnRelease()
    {
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if (hitInfo.transform.CompareTag("Cell"))
                Debug.Log($"I hit the cell {hitInfo.transform.name}");
            else
                Debug.Log($"I hit something of name {hitInfo.transform.name}");
        }
        else
            Debug.Log("I hit nothing");
        _uiHandHolder.SetActive(true);
        _isCardSelected = false;
        _currentCardSelected.gameObject.SetActive(false);
    }
    public void DisplayCard()
    {
        for (int i = 0; i < _currentHand.Length; i++)
        {
            _currentHand[i] = Instantiate(_cardHandPrefab);
            _currentHand[i].transform.SetParent(_handParent);
            _currentHand[i].transform.localScale = Vector3.one;
            _currentHand[i].onPressEvent += OnPress;
        }
    }


    public void OnDrag(PointerEventData eventData)
    {
        if (_isCardSelected)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            newPosition.z = Camera.main.nearClipPlane;
            _currentCardSelected.transform.position = Camera.main.ScreenToWorldPoint(newPosition);
            Debug.Log($"Cyrrent position {_currentCardSelected.transform.position}, screen to pint {newPosition}, mouse position {Mouse.current.position.ReadValue()}");
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        OnRelease();
    }
}
