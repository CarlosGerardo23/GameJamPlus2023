using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCombinationController : MonoBehaviour
{
    [SerializeField] private List<GemCradCombinationData> _combinations;
    public TarotCardsSO GetTarotCard(GemType first, GemType second)
    {
        for (int i = 0; i < _combinations.Count; i++)
        {
            if(_combinations[i].TryGetCombination(first, second, out TarotCardsSO card))
            return card;
        }
        return null;
    }
}
