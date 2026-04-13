using UnityEngine;

public class CardViewHoverSystem : Singleton<CardViewHoverSystem>
{
    [SerializeField] private CardView cardViewHover;

    public void Show(Card card, Vector3 position)
    {
        cardViewHover.gameObject.SetActive(true);
        cardViewHover.Setup(card);

        RectTransform hoverRect = cardViewHover.GetComponent<RectTransform>();
        hoverRect.anchoredPosition = new Vector2(0f, 200f);
        hoverRect.localScale = Vector3.one;
        hoverRect.SetAsLastSibling();
    }

    public void Hide()
    {
        cardViewHover.gameObject.SetActive(false);
    }
}
