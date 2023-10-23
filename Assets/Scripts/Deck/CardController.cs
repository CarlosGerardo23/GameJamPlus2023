using UnityEngine.UI;
using UnityEngine;

public class CardController : MonoBehaviour
{
    private TarotCardsSO _cardSO;
    private SpriteRenderer _cardImage;
    // Start is called before the first frame update
    void Awake()
    {
        _cardImage= GetComponentInChildren<SpriteRenderer>();
    }
   
   public void SetCard(TarotCardsSO card)
   {
        _cardSO=card;
        _cardImage.sprite= card.icon;
        _cardImage.transform.localScale=Vector3.one;
        
   }
}
