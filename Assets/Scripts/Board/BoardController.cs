using UnityEngine;
using UnityEngine.InputSystem;

public class BoardController : MonoBehaviour
{
    [SerializeField] private InputReaderSO _inputReader;
    [SerializeField] private CardController _tarotCard;
    private UIHandController _handController;
    private Animator _animator;
    private bool _isBoard;
    private Camera _mainCamera;
    private CardCombinationController _cardCombination;
    private GemCardSO _currentGemSelected;
    private GemCardSO _firstBoardSelection;
    private GemCardSO _secondBoardSelection;
    private void Awake()
    {
        _handController = FindObjectOfType<UIHandController>();
        _animator = GetComponent<Animator>();
        _animator.SetBool("Card", true);
        _animator.SetBool("Board", false);
        _mainCamera = Camera.main;
        _cardCombination = GetComponent<CardCombinationController>();
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
                if (hitInfo.transform.CompareTag("Selectable"))
                    hitInfo.transform.GetComponent<Selectable>().DoAction();
                else if (hitInfo.transform.CompareTag("Forge"))
                {
                    hitInfo.transform.GetComponent<Selectable>().DoActionWithCard(_currentGemSelected);
                    CheckCombination(_currentGemSelected);
                }
            }
        }
        else
            SetBoard(null);

    }
    private void OnExtitBoard()
    {
        _animator.SetBool("Card", true);
        _animator.SetBool("Board", false);
        _handController.DisplayCard();
        _isBoard = false;
    }
    public void SetBoard(GemCardSO currentGemSelected)
    {
        _animator.SetBool("Board", true);
        _animator.SetBool("Card", false);
        _isBoard = true;
        _currentGemSelected = currentGemSelected;
    }

    private void CheckCombination(GemCardSO card)
    {
        if (_firstBoardSelection == null)
        {
            _firstBoardSelection = card;
            OnExtitBoard();
            return;
        }

        _secondBoardSelection = card;
        TarotCardsSO _tarotData = _cardCombination.GetTarotCard(_firstBoardSelection.GemType, _secondBoardSelection.GemType);
        if (_tarotData != null)
            _tarotCard.SetCard(_tarotData);
        else
            OnExtitBoard();

    }
}
