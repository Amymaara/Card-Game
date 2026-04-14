using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardView : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IBeginDragHandler,
    IDragHandler,
    IEndDragHandler
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;
    [SerializeField] private TMP_Text cardCost;
    [SerializeField] private Image imageSR;
    [SerializeField] private CanvasGroup canvasGroup;

    private RectTransform rectTransform;
    private RectTransform parentRect;
    private HandView handView;

    private Vector2 dragOffset;
    private int originalSiblingIndex;

    public Card Card { get; private set; }
    public bool IsDragging { get; private set; }
    public bool WasPlayed { get; set; }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        parentRect = transform.parent as RectTransform;
        handView = GetComponentInParent<HandView>();

        if (canvasGroup == null)
            canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Setup(Card card)
    {
        Card = card;
        title.text = card.Title;
        description.text = card.Description;
        cardCost.text = card.CardCost.ToString();
        imageSR.sprite = card.Image;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (IsDragging) return;

        rectTransform.DOKill();
        rectTransform.DOScale(Vector3.one * 1.1f, 0.12f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (IsDragging) return;

        rectTransform.DOKill();
        rectTransform.DOScale(Vector3.one, 0.12f);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        WasPlayed = false;
        IsDragging = true;
        originalSiblingIndex = transform.GetSiblingIndex();

        if (Interactions.Instance != null)
            Interactions.Instance.StartDragging();

        if (parentRect == null)
            parentRect = transform.parent as RectTransform;

        rectTransform.DOKill();
        transform.SetAsLastSibling();
        rectTransform.localRotation = Quaternion.identity;
        rectTransform.localScale = Vector3.one * 1.1f;

        if (canvasGroup != null)
            canvasGroup.blocksRaycasts = false;

        if (parentRect == null) return;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentRect,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 pointerLocalPos
        );

        dragOffset = rectTransform.anchoredPosition - pointerLocalPos;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!IsDragging) return;
        if (parentRect == null)
            parentRect = transform.parent as RectTransform;
        if (parentRect == null) return;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            parentRect,
            eventData.position,
            eventData.pressEventCamera,
            out Vector2 pointerLocalPos
        );

        rectTransform.anchoredPosition = pointerLocalPos + dragOffset;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!IsDragging) return;

        IsDragging = false;

        if (Interactions.Instance != null)
            Interactions.Instance.StopDragging();

        if (canvasGroup != null)
            canvasGroup.blocksRaycasts = true;

        rectTransform.DOKill();

        if (WasPlayed)
        {
            return;
        }

        transform.SetSiblingIndex(originalSiblingIndex);
        rectTransform.localScale = Vector3.one;

        if (handView == null)
            handView = GetComponentInParent<HandView>();

        if (handView != null)
            handView.RefreshLayoutImmediate();
    }
}