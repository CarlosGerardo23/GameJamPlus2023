using System;
using UnityEngine;
[CreateAssetMenu(menuName = "Challenge")]
public class ChallengeSO : ScriptableObject
{
    [SerializeField] private PlayerDataSO.LifeDataType _challengeType;
    [SerializeField] private GemCardSO[] _succesReward;
    [SerializeField] private int _lifeDataPenalitation;
    [SerializeField] private int _succesPercentage;
    public PlayerDataSO.LifeDataType ChallengeType => _challengeType;
    public Action<GemCardSO[]> OnChallengeSucces;
    public Action<PlayerDataSO.LifeDataType, int> OnChallengeFailed;
    private bool _challengeResult;
    public void GetChallengeResult(int succesPercentageOffset)
    {
        int succesPercentage = (_succesPercentage + succesPercentageOffset) > 100 ? 100 : _succesPercentage + succesPercentageOffset;
        succesPercentage = (_succesPercentage + succesPercentageOffset) < 0 ? 0 : _succesPercentage + succesPercentageOffset;

        int randomNumber = UnityEngine.Random.Range(0, 101);
        _challengeResult = succesPercentage >= randomNumber;
        if (_challengeResult)
        {
            Debug.Log($"Challenge succesull, with succes perecentage{succesPercentage},result number {randomNumber}, {_challengeType}");
            OnChallengeSucces?.Invoke(_succesReward);
        }
        else
        {
            Debug.Log($"Challenge FAILED, with succes perecentage{succesPercentage},result number {randomNumber}, {_challengeType}");

            OnChallengeFailed?.Invoke(_challengeType, _lifeDataPenalitation);
        }
    }
    public void DoChallengeAction()
    {
        if (_challengeResult)
            OnChallengeSucces?.Invoke(_succesReward);
        else
            OnChallengeFailed?.Invoke(_challengeType, _lifeDataPenalitation);
    }
}
