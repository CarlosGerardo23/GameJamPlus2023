using UnityEngine;
public class ChallengeSelectable : Selectable
{
    [SerializeField] private ChallengeSO _challegeSO;
    [SerializeField] private PlayerDataSO _playerData;
    private DeckController _deckController;
    public GemCardSO GemCard => (GemCardSO)_currentCard;
    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _deckController = FindObjectOfType<DeckController>();
    }
    private void OnEnable()
    {
        _challegeSO.OnChallengeSucces += _deckController.AddToDeckAndReset;
        _challegeSO.OnChallengeFailed += _playerData.RestFailedCard;
    }
    private void OnDisable()
    {
        _challegeSO.OnChallengeSucces -= _deckController.AddToDeckAndReset;
        _challegeSO.OnChallengeFailed -= _playerData.RestFailedCard;
    }
    public override void DoAction()
    {
        int addPercentage = _currentCard != null ? ((GemCardSO)_currentCard).GetAffectPercentageValue() : 0;
        _challegeSO.GetChallengeResult(addPercentage);
        GemCard?.ResetOffsetValue();
    }
}
