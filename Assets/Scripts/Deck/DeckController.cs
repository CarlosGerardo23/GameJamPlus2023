using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// The minor crads deck controller, handle the current cards on the deck and on the hand
/// </summary>
public class DeckController : MonoBehaviour
{
    [SerializeField] private UnityEvent onLoseGame;
    private List<GemCardSO> _currentDeck = new List<GemCardSO>();
    [SerializeField] private List<GemCardSO> _allDeck = new List<GemCardSO>();
    public GemCardSO[] HandOfCards { get; private set; }

    private void Awake()
    {
        for (int i = 0; i < _allDeck.Count; i++)
            _currentDeck.Add(_allDeck[i]);

        RandomizeListFisherYates();
        GetCards();
    }
    public void AddToDeckAndReset(GemCardSO toAdd)
    {
        _allDeck.Add(toAdd);
        _currentDeck = new List<GemCardSO>();
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
        if (_currentDeck.Count == 0)
            onLoseGame.Invoke();

        HandOfCards[0] = _currentDeck[0];
        HandOfCards[1] = _currentDeck[1];
        HandOfCards[2] = _currentDeck[2];
    }
    public void RemoveCard(GemCardSO card)
    {
        _currentDeck.Remove(card);
    }
    /// <summary>
    /// Randomize the deck using the algorithm Fisher-Yates
    /// </summary>
    private void RandomizeListFisherYates()
    {
        for (int i = _currentDeck.Count - 1; i > 0; i--)
        {
            int indexSelected = Random.Range(0, i);
            GemCardSO currentCard = _currentDeck[i];
            _currentDeck[i] = _currentDeck[indexSelected];
            _currentDeck[indexSelected] = currentCard;
        }
    }
}
