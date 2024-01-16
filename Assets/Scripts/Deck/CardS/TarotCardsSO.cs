using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Tarot Card")]
public class TarotCardsSO : CardSO
{
   [SerializeField] private List<TarotEffectGem> _gemsToAffectList = new List<TarotEffectGem>();

   public void SetObjectsToAffect(GemCardSO gem)
   {
      if (gem == null) return;
      for (int i = 0; i < _gemsToAffectList.Count; i++)
      {
         if (_gemsToAffectList[i].gemToAffect == gem.GemType)
         {
            _gemsToAffectList[i].card = gem;
            break;
         }
      }
   }
   public void AffectCards()
   {
      foreach (var effect in _gemsToAffectList)
         effect.AffectCard();
   }
}
