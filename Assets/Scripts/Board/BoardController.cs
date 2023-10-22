using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem;

public class BoardController : MonoBehaviour
{
    [SerializeField] private InputReaderSO _inputReader;
    private Animator _animator;
    private bool _isBoard;
    private Camera _mainCamera;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("Card", true);
        _animator.SetBool("Board", false);
        _mainCamera = Camera.main;
    }
    private void OnEnable()
    {
        _inputReader.onSelectEvent += OnSelectEvent;
        _inputReader.onChangeToCardsEvent += OnExtitBoard;
        _inputReader.EnableBoardInputs();
    }
    private void OnDisable()
    {
        _inputReader.onSelectEvent -= OnSelectEvent;
        _inputReader.onChangeToCardsEvent -= OnExtitBoard;
    }
    private void OnSelectEvent()
    {
        if (_isBoard)
        {
            Ray ray = _mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if(hitInfo.transform.CompareTag("Selectable"))
                {
                    hitInfo.transform.GetComponent<Selectable>().DoAction();
                }
            }
        }
        else
        {
            _animator.SetBool("Board", true);
            _animator.SetBool("Card", false);
            _isBoard = true;
        }
    }
    private void OnExtitBoard()
    {
        _animator.SetBool("Card", true);
        _animator.SetBool("Board", false);
        _isBoard = false;
    }
}
