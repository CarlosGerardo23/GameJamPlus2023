using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class ForgeSelectable : Selectable
{
    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    public override void DoAction()
    {
        throw new System.NotImplementedException();
    }

    public override void DoActionWithCard(CardSO card)
    {
        _spriteRenderer.sprite = card.icon;
    }
}
