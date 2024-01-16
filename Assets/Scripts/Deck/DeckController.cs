using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// The minor crads deck controller, handle the current cards on the deck and on the hand
/// </summary>
public class DeckController : MonoBehaviour
{
    [SerializeField] private UnityEvent onLoseGame;
    [SerializeField] private List<GemCardSO> _allDeck = new List<GemCardSO>();
    [SerializeField] private int _initialNumberCards = 3;
    public int CurrentCardsInDeck=>_currentDeck.Count;
    private List<GemCardSO> _currentDeck = new List<GemCardSO>();


    private void Awake()
    {
        for (int i = 0; i < _allDeck.Count; i++)
            _currentDeck.Add(_allDeck[i]);

        RandomizeListFisherYates();
    }
    public void AddToDeckAndReset(GemCardSO[] toAdd)
    {
    foreach (var card in toAdd)
    {
          _allDeck.Add((GemCardSO)card);
        _currentDeck = new List<GemCardSO>();
        for (int i = 0; i < _allDeck.Count; i++)
        {
            _currentDeck.Add(_allDeck[i]);
        }
        GetCards();
    }
      
    }
    public List<GemCardSO> GetCards()
    {
        List<GemCardSO> result = new List<GemCardSO>();
        for (int i = 0; i < _initialNumberCards; i++)
            result.Add(_currentDeck[i]);
        for (int i = 0; i < result.Count; i++)
            RemoveCard(result[i]);

        return result;
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
