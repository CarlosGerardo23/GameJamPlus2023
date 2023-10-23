using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ChallengeSelectable : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private List<Challenge> _currentChallenges;
    [SerializeField] private UnityEvent _onFirstChallengeCompleted;
    [SerializeField] private UnityEvent _onFirstChallengeFailTry;
    [SerializeField] private UnityEvent _onSecondChallengeCompleted;
    [SerializeField] private UnityEvent _onSecondChallengeFailTry;
    [SerializeField] private UnityEvent _onThirdChallengeCompleted;
    [SerializeField] private UnityEvent _onThirdChallengeFailTry;
    private Challenge _currentChallenge;
    private int _currentIndex = 0;
    private void Start()
    {
        _currentChallenge = _currentChallenges[_currentIndex];
        _spriteRenderer.sprite = _currentChallenge.tarotCard.icon;
    }

    public void CheckWinningCondition(TarotCardsSO tarot)
    {
        if (_currentChallenge.tarotCard == tarot)
        {
            switch (_currentChallenge.challengeType)
            {
                case ChallengeType.FIRST:
                    _onFirstChallengeCompleted.Invoke();
                    _currentIndex++;
                    _currentChallenge = _currentChallenges[_currentIndex];
                    _spriteRenderer.sprite = _currentChallenge.tarotCard.icon;
                    break;
                case ChallengeType.SECOND:
                    _onSecondChallengeCompleted.Invoke();
                    _currentIndex++;
                    _currentChallenge = _currentChallenges[_currentIndex];
                    _spriteRenderer.sprite = _currentChallenge.tarotCard.icon;
                    break;
                case ChallengeType.THIRD:
                    _onFirstChallengeCompleted.Invoke();
                    break;
            }

        }
        else
        {
            switch (_currentChallenge.challengeType)
            {
                case ChallengeType.FIRST:
                    _onFirstChallengeFailTry.Invoke();
                    break;
                case ChallengeType.SECOND:
                    _onSecondChallengeFailTry.Invoke();
                    break;
                case ChallengeType.THIRD:
                    _onThirdChallengeFailTry.Invoke();
                    break;
            }
        }
    }

    public void DebugLogs(string logs)
    {
        Debug.Log($"Logs: {logs}");
    }
}
[System.Serializable]
class Challenge
{
    public ChallengeType challengeType;
    public TarotCardsSO tarotCard;
}
public enum ChallengeType { FIRST, SECOND, THIRD };