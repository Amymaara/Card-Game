using UnityEngine;
using UnityEngine.EventSystems;

public class DropAreaZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        CardView cardView = eventData.pointerDrag != null
            ? eventData.pointerDrag.GetComponent<CardView>()
            : null;

        if (cardView == null) return;

        cardView.WasPlayed = true;

        PlayCardGA playCardGA = new(cardView.Card);
        ActionSystem.Instance.Perform(playCardGA);
    }
}
