using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GemCradCombinationData
{
    [SerializeField] private TarotCardsSO _tarotCardData;
    [SerializeField] private GemType _fisrtCard;
    [SerializeField] private GemType _secondType;

    public bool TryGetCombination(GemType first, GemType second, out TarotCardsSO card)
    {
        bool result = false;
        card = null;
        if ((first == _fisrtCard) && (second == _secondType))
            result = true;
        if ((first == _secondType) && (second == _fisrtCard))
            result = true;
        card = _tarotCardData;
        return result;
    }
}
