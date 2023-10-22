using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChallengeSelectable : Selectable
{
    public override void DoAction()
    {
        Debug.Log($"This action is activated {transform.name}");
    }
}