using UnityEngine;

public abstract class Selectable : MonoBehaviour
{
    [SerializeField] private Sprite _outline;
    protected CardSO _currentCard;
    protected SpriteRenderer _spriteRenderer;
    public abstract void DoAction();

    public void SetCardOnSelectable(CardSO card)
    {
        _currentCard = card;
        _spriteRenderer.sprite = card.icon;
    }
    public void ResetCard()
    {
        _spriteRenderer.sprite = _outline;
    }
}
