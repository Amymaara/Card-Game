using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class HandView : MonoBehaviour
{
    [SerializeField] private float spacing = 160f;
    [SerializeField] private float curveHeight = 35f;
    [SerializeField] private float maxRotation = 12f;

    private readonly List<CardView> cards = new();

    public IEnumerator AddCard(CardView cardView)
    {
        RectTransform rect = cardView.GetComponent<RectTransform>();
        rect.SetParent(transform, false);
        rect.localScale = Vector3.one;

        cards.Add(cardView);
        yield return UpdateCardPositions(0.2f);
    }

    private IEnumerator UpdateCardPositions(float duration)
    {
        if (cards.Count == 0)
            yield break;

        float centerOffset = (cards.Count - 1) / 2f;

        for (int i = 0; i < cards.Count; i++)
        {
            RectTransform rect = cards[i].GetComponent<RectTransform>();

            float normalized = cards.Count == 1 ? 0f : (i - centerOffset) / centerOffset;
            if (cards.Count == 1) normalized = 0f;

            float x = (i - centerOffset) * spacing;
            float y = -Mathf.Abs(normalized) * 20f + curveHeight;
            float zRotation = -normalized * maxRotation;

            rect.DOAnchorPos(new Vector2(x, y), duration);
            rect.DOLocalRotate(new Vector3(0f, 0f, zRotation), duration);

            rect.SetSiblingIndex(i);
        }

        yield return new WaitForSeconds(duration);
    }
}