using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine;
using Unity.VisualScripting;
[CreateAssetMenu(menuName = "Inputs")]
public class InputReaderSO : ScriptableObject, GameInputs.IBoardActions
{
    public Action onSelectEvent;
    public Action onChangeToCardsEvent;
    private GameInputs _gameInputs;
    private void OnEnable()
    {
        if (_gameInputs == null)
        {
            _gameInputs = new GameInputs();
            _gameInputs.Board.SetCallbacks(this);

        }
    }
    public void OnSelect(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            onSelectEvent();
    }
    public void OnViewCards(InputAction.CallbackContext context)
    {
        onChangeToCardsEvent();
    }
    public void EnableBoardInputs()
    {
        _gameInputs.Board.Enable();
    }


}
