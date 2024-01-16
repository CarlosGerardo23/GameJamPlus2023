using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Cards/Gem")]
public class GemCardSO : CardSO
{
   [SerializeField] private GemType _gemType;
   [SerializeField] private int _affectPercentageValue = 10;
   private int _offsetPercentage = 0;

   public void AddToOffsetPercentageValue(int value)
   {
      _offsetPercentage = value;
   }
   public int GetAffectPercentageValue()
   {
      return _affectPercentageValue + _offsetPercentage;
   }
   public void ResetOffsetValue()
   {
      _offsetPercentage = 0;
   }
   public GemType GemType => _gemType;
}
public enum GemType { LOVE, WISDOM, EQUITY, DETERMINATION, CHANGE, HOPE, INSPRATION }