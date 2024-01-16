using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TarotSelectable : Selectable
{
    [SerializeField]private PlayerDataSO _playerData;
    [SerializeField]private ChallengeSelectable _selectable;
    private TarotEffectLifeData[] _lifeData;
    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    public override void DoAction()
    {
        ((TarotCardsSO)_currentCard).SetObjectsToAffect(_selectable.GemCard);
        ((TarotCardsSO)_currentCard).AffectCards();      
    }
}
