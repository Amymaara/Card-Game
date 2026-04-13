using TMPro;
using UnityEngine;

public class CardView : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;
    [SerializeField] private TMP_Text cardCost;
    [SerializeField] private SpriteRenderer imageSR;
    [SerializeField] private GameObject cardView;

    public Card Card { get; private set; }
    public void Setup(Card card)
    {
        Card = card;
        title.text = card.Title;
        description.text = card.Description;  
        cardCost.text = card.CardCost.ToString();
        imageSR.sprite = card.Image;

    }
}
