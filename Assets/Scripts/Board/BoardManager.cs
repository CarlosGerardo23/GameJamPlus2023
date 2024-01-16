using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoardManager : MonoBehaviour
{
    [SerializeField] private PlayerDataSO _playerData;
    [SerializeField] private InputReaderSO _inputReader;
    private TarotCardsManager _tarotManager;
    private ChallengeSelectable[] _challengesSelectablesList;
    private UIHandController _uIHandController;
    private Animator _animator;
    private bool _isBoardActivated;
    private Camera _mainCamera;
    private void Awake()
    {
        _tarotManager= FindObjectOfType<TarotCardsManager>();
        _uIHandController = FindObjectOfType<UIHandController>();
        _mainCamera = Camera.main;
        SetAnimationVariables();
        _challengesSelectablesList = GetComponentsInChildren<ChallengeSelectable>();

    }
    private void OnEnable()
    {
        _inputReader.onSelectEvent += OnSelectEvent;
        _inputReader.onChangeToCardsEvent += ChangeBoardState;
        _inputReader.EnableBoardInputs();
    }
    private void OnDisable()
    {
        _inputReader.onSelectEvent -= OnSelectEvent;
        _inputReader.onChangeToCardsEvent -= ChangeBoardState;
    }
    #region Board Game Behaviour
    public void SetGemCardOnBoard()
    {
        ActivateBoardState();
    }
    private void OnSelectEvent()
    {
        if (_isBoardActivated)
        {
            if (TryHitChallenge(out ChallengeSelectable selectable))
            {
                selectable.SetCardOnSelectable(_playerData.cardSelected.Card);
                _playerData.cardSelected.onFinishBoard?.Invoke(_playerData.cardSelected);
                DesactivateBoardState();
            }
        }
        else
            ActivateBoardState();

    }
    private bool TryHitChallenge(out ChallengeSelectable selectable)
    {
        selectable = null;
        Ray ray = _mainCamera.ScreenPointToRay(_inputReader.GetMousePosition());
        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            selectable = hitInfo.transform.GetComponent<ChallengeSelectable>();
            return selectable != null && _playerData.HaveCardSelected;
        }
        return false;
    }
    #endregion
    #region Board Controller State
    private void ChangeBoardState()
    {
        if (_isBoardActivated)
            DesactivateBoardState();
        else
            ActivateBoardState();
    }
    private void ActivateBoardState()
    {
        DoBaordActivationAnimationState(true);
        _isBoardActivated = true;
        _uIHandController.SetCardsVisualsState(false);
    }
    private void DesactivateBoardState()
    {
        DoBaordActivationAnimationState(false);
        _isBoardActivated = false;
        _uIHandController.SetCardsVisualsState(true);
    }
    #endregion
    #region Animation Behaviour
    private void SetAnimationVariables()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("Card", true);
        _animator.SetBool("Board", false);
        _isBoardActivated = false;
    }
    private void DoBaordActivationAnimationState(bool state)
    {
        _animator.SetBool("Board", state);
        _animator.SetBool("Card", !state);

    }
    #endregion
    #region Inspector Events
    public void DoChallenges()
    {
        _tarotManager.DoActions();
        for (int i = 0; i < _challengesSelectablesList.Length; i++)
        {
            _challengesSelectablesList[i].DoAction();
            StartCoroutine(GoBackToTheMainMenu());
        }
    }
    private IEnumerator GoBackToTheMainMenu()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(0);
    }
    #endregion
}
