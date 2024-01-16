using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class GemSelectable : Selectable
{
    [SerializeField] private int _percentageAdded;
    private ChallengeSO _challegeSO;
    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    public void GetCurrentChallenge(ChallengeSO currentChallenge)
    {
        _challegeSO = currentChallenge;
    }
    public override void DoAction()
    {
        _challegeSO.GetChallengeResult(_percentageAdded);
    }
}
