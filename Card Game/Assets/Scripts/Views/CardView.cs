using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;
    [SerializeField] private TMP_Text cardCost;
    [SerializeField] private Image imageSR;
    [SerializeField] private CanvasGroup canvasGroup;

    private HandView handView;

    private RectTransform rectTransform;
    private Canvas parentCanvas;

    private Vector2 baseAnchoredPosition;
    private Vector3 baseScale;
    private Vector3 baseRotation;
    private bool isHovered;

    public Card Card { get; private set; }

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        handView = GetComponentInParent<HandView>();

        if (canvasGroup == null)
            canvasGroup = GetComponent<CanvasGroup>();
    }

    public void SetBaseTransform(Vector2 anchoredPos, Vector3 rotation, Vector3 scale)
    {
        baseAnchoredPosition = anchoredPos;
        baseRotation = rotation;
        baseScale = scale;

        if (!isHovered && !Interactions.Instance.PlayerIsDragging)
        {
            rectTransform.anchoredPosition = baseAnchoredPosition;
            rectTransform.localEulerAngles = baseRotation;
            rectTransform.localScale = baseScale;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!Interactions.Instance.PlayerCanHover()) return;
        if (Interactions.Instance.PlayerIsDragging) return;

        isHovered = true;
        rectTransform.DOKill();
        rectTransform.DOScale(Vector3.one * 1.15f, 0.12f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (Interactions.Instance.PlayerIsDragging) return;

        isHovered = false;
        rectTransform.DOKill();
        rectTransform.DOScale(Vector3.one, 0.12f);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Interactions.Instance == null || !Interactions.Instance.PlayerCanInteract()) return;

        handView = GetComponentInParent<HandView>();
        Interactions.Instance.StartDragging();

        rectTransform.DOKill();

        if (canvasGroup != null)
            canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Interactions.Instance == null || !Interactions.Instance.PlayerCanInteract()) return;

        if (rectTransform == null)
            rectTransform = GetComponent<RectTransform>();

        Canvas canvas = GetComponentInParent<Canvas>();
        if (canvas == null) return;

        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Interactions.Instance == null || !Interactions.Instance.PlayerCanInteract()) return;

        Interactions.Instance.StopDragging();

        if (canvasGroup != null)
            canvasGroup.blocksRaycasts = true;

        rectTransform.DOKill();
        rectTransform.DOScale(Vector3.one, 0.15f);

        HandView handView = GetComponentInParent<HandView>();
        if (handView != null)
        {
            handView.RefreshLayoutImmediate();
        }
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
