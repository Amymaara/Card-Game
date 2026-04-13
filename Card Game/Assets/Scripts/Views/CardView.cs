using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;
    [SerializeField] private TMP_Text cardCost;
    [SerializeField] private Image imageSR;

    private RectTransform rectTransform;
    private Vector2 originalPos;
    private Vector3 originalScale;
    private Vector3 originalRotation;

    public Card Card { get; private set; }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        originalPos = rectTransform.anchoredPosition;
        originalScale = rectTransform.localScale;
        originalRotation = rectTransform.localEulerAngles;

        transform.SetAsLastSibling();

        rectTransform.DOAnchorPos(originalPos + new Vector2(0f, 120f), 0.15f);
        rectTransform.DOScale(1.2f, 0.15f);
        rectTransform.DOLocalRotate(Vector3.zero, 0.15f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rectTransform.DOAnchorPos(originalPos, 0.15f);
        rectTransform.DOScale(originalScale, 0.15f);
        rectTransform.DOLocalRotate(originalRotation, 0.15f);
    }

    public void Setup(Card card)
    {
        Card = card;
        title.text = card.Title;
        description.text = card.Description;
        cardCost.text = card.CardCost.ToString();
        imageSR.sprite = card.Image;
    }
}
