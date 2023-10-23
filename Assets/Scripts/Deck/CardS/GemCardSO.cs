using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Cards/Gem")]
public class GemCardSO : CardSO
{
    
   [SerializeField] private GemType _gemType;
   public GemType GemType => _gemType;
}
public enum GemType{LOVE,WISDOM,EQUITY,DETERMINATION,CHANGE,HOPE,INSPRATION}