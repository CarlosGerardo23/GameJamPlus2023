using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Selectable : MonoBehaviour
{
    public abstract void DoAction();

    public abstract void DoActionWithCard(CardSO card);
}
