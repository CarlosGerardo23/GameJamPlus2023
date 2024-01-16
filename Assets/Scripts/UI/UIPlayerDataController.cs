using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayerDataController : MonoBehaviour
{
    [SerializeField] private PlayerDataSO _playerData;
    [SerializeField] private UnityEngine.UI.Slider _sliderHealth;
    [SerializeField] private UnityEngine.UI.Slider _sliderMoney;
    [SerializeField] private UnityEngine.UI.Slider _sliderRelantioship;

    void Update()
    {
        _sliderHealth.value = _playerData.healthPoints;
        _sliderMoney.value = _playerData.moneyPoints;
        _sliderRelantioship.value = _playerData.relationshipsPoints;
    }
}
