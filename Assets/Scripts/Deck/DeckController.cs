using System.Collections.Generic;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    private List<GemCardSO> _currentDeck = new List<GemCardSO>();
    [SerializeField] private List<GemCardSO> _allDeck = new List<GemCardSO>();
    public GemCardSO[] HandOfCards { get; private set; }

    private void Awake()
    {
        for (int i = 0; i < _allDeck.Count; i++)
        {
            _currentDeck.Add(_allDeck[i]);
        }
        GetCards();
    }

    public void GetCards()
    {
        if (HandOfCards == null)
            HandOfCards = new GemCardSO[3];

        System.Random random = new System.Random();
        for (int i = 0; i < HandOfCards.Length; i++)
        {
            if (HandOfCards[i] == null)
                HandOfCards[i] = _currentDeck[random.Next(0, _currentDeck.Count)];
        }
        for (int i = 0; i < HandOfCards.Length; i++)
        {
            _currentDeck.Remove(HandOfCards[i]);
        }
    }
}
