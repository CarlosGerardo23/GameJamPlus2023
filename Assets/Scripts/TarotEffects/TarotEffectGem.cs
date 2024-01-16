using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class TarotEffectGem
{
  public GemType gemToAffect;
  [SerializeField] private int value;
  public GemCardSO card;

    public void AffectCard()
    {
        card?.AddToOffsetPercentageValue(value);
    }
}
