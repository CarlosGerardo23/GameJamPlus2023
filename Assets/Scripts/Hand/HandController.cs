using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class HandController : MonoBehaviour
{
    [SerializeField] private PlayerDataSO _playerData;
    private DeckController _deckController;

    private void Awake()
    {
        _deckController = FindObjectOfType<DeckController>();
    }
    private void Start()
    {
        _playerData.cardsInHand=_deckController.GetCards();
    }
}
