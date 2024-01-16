using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TarotCardsManager : MonoBehaviour
{
    [SerializeField] private TarotCardsSO[] _tarotCardsList;
    private List<TarotCardsSO> _currentTarotCards = new List<TarotCardsSO>();
    private TarotSelectable[] _selectablesList;

    private void Awake()
    {
        _selectablesList = GetComponentsInChildren<TarotSelectable>();
    }

    private void Start()
    {
        foreach (var card in _tarotCardsList)
        {
            _currentTarotCards.Add(card);
        }

        foreach (var selectable in _selectablesList)
        {
            TarotCardsSO card = _currentTarotCards[Random.Range(0, _currentTarotCards.Count)];
            selectable.SetCardOnSelectable(card);
            _currentTarotCards.Remove(card);
        }
    }
    public void DoActions()
    {
        foreach (var selectable in _selectablesList)
        {
            selectable.DoAction();
        }
    }
}
