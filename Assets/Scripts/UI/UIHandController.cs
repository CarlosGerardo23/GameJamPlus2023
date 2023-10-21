using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHandController : MonoBehaviour
{
    [SerializeField] private GameObject _cardHandPrefab;
    [SerializeField] private GameObject _cardOnHandPrefab;
    [SerializeField] private GameObject _uiHandHolder;
    private DeckController _deck;
    private GameObject[] _currentHand= new GameObject[5];
    private GameObject _currentCardSelected;
    private void Awake()
    {
        _deck = FindObjectOfType<DeckController>();
    }
    void Start()
    {

    }
    void Update()
    {

    }
    public void OnPress()
    {
        _uiHandHolder.SetActive(false);
        
    }
    public void DisplayCard()
    {
        for(int i=0; i<_currentHand.Length; i++)
        {
           // _cardHandPrefab.GetComponent<Button>().onClick.AddListener(_deck.HandOfCards[i].Do)
        }
    }
}
