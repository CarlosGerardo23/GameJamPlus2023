using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDeckController : MonoBehaviour
{
    private DeckController _deckController;
    [SerializeField] private TMPro.TextMeshProUGUI _text;

    private void Awake()
    {
        _deckController = FindObjectOfType<DeckController>();
    }
    // Update is called once per frame
    void Update()
    {
        _text.text = _deckController.CurrentCardsInDeck.ToString();
    }
}
