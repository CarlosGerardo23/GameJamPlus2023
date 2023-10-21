using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Card/Move")]
public class MoveUnitsCardSO : CardSO
{
    public override void DoCardAction(MinionController minion)
    {
       Debug.Log("Minion move");
    }
}
