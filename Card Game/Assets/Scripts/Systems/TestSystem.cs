using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestSystem : MonoBehaviour
{
    [SerializeField] private HandView handView;
    [SerializeField] private InputActionReference spaceAction;
    //[SerializeField] private CardData cardData;

    /* private void OnEnable()
     {
         if (spaceAction == null)
         {
             Debug.LogError("Space Action is not assigned in the Inspector.", this);
             return;
         }

         spaceAction.action.Enable();
     }

     private void OnDisable()
     {
         if (spaceAction != null)
             spaceAction.action.Disable();
     }

     private void Update()
     {
         if (spaceAction == null)
         {
             Debug.LogError("spaceAction is null.", this);
             return;
         }

         if (!spaceAction.action.triggered)
             return;

         if (handView == null)
         {
             Debug.LogError("handView is not assigned in the Inspector.", this);
             return;
         }

         if (CardViewCreator.Instance == null)
         {
             Debug.LogError("CardViewCreator.Instance is null. Make sure CardViewCreator exists in the scene.", this);
             return;
         }

         Card card = new(cardData);

         CardView cardView = CardViewCreator.Instance.CreateCardView(card, transform.position, Quaternion.identity);

         if (cardView == null)
         {
             Debug.LogError("CreateCardView returned null.", this);
             return;
         }

         StartCoroutine(handView.AddCard(cardView));
     } */

    [SerializeField] private List<CardData> deckData;

    private void Start()
    {
        CardSystem.Instance.Setup(deckData);
    }

}
