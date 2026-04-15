using UnityEngine;
using UnityEngine.EventSystems;

public class DropAreaZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        CardView cardView = eventData.pointerDrag?.GetComponent<CardView>();
        if (cardView == null) return;

        if (!Interactions.Instance.PlayerCanInteract()) return;
        if (!CardCostSystem.Instance.HasEnoughCardCost(cardView.Card.CardCost)) return;

        cardView.WasPlayed = true;

        PlayCardGA playCardGA = new(cardView.Card);
        ActionSystem.Instance.Perform(playCardGA);
    }
}
