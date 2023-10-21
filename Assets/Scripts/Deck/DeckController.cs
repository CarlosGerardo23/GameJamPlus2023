using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    [SerializeField] private List<CardSO> _currentDeck = new List<CardSO>();
    public CardSO[] HandOfCards{get; private set;}

    private void Awake()
    {
        GetCards();
    }

    private void GetCards()
    {
        System.Random random= new System.Random();
        for(int i=0; i< HandOfCards.Length; i++)
        {
            HandOfCards[i]  = _currentDeck[random.Next(0,_currentDeck.Count)];
        }
    }
}
