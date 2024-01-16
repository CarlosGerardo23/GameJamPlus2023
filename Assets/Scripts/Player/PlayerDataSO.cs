using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu(menuName = "Player Data")]
public class PlayerDataSO : ScriptableObject
{
    public enum LifeDataType { MONEY, RELANTIONSHIPS, HEALTH };
    public List<GemCardSO> cardsInHand;
    [Range(0, 10)]
    public int healthPoints;
    [Range(0, 10)]
    public int moneyPoints;
    [Range(0, 10)]
    public int relationshipsPoints;
    public UICardController cardSelected;

    public bool HaveCardSelected => cardSelected != null;
    private void OnEnable()
    {
        cardsInHand = new List<GemCardSO>();
        healthPoints = 10;
        moneyPoints = 10;
        relationshipsPoints = 10;
        cardSelected = null;
    }
    public void RestFailedCard(LifeDataType lifeData, int value)
    {
        switch (lifeData)
        {
            case LifeDataType.HEALTH:
                healthPoints += value;
                break;
            case LifeDataType.RELANTIONSHIPS:
                relationshipsPoints += value;
                break;
            case LifeDataType.MONEY:
                moneyPoints += value;
                break;
            default:
                break;
        }
    }

}
