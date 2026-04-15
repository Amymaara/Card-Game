using System.Collections;
using UnityEngine;

public class CardCostSystem : Singleton<CardCostSystem>
{
    [SerializeField] private CardCostUI cardCostUI;

    private const int MAX_CARDCOST = 3;

    private int currentCardCost = MAX_CARDCOST;

    private void Start()
    {
        cardCostUI.UpdateCardCostText(currentCardCost);
    }
    private void OnEnable()
    {
        ActionSystem.AttachPerformer<SpentCardCostGA>(SpendCardCostPerformer);
        ActionSystem.AttachPerformer<RefillCardCostGA>(RefillCardCostPerformer);
        ActionSystem.SubscribeReaction<EnemyTurnGA>(EnemyTurnPostReaction,ReactionTiming.POST);
    }
    private void OnDisable()
    {
        ActionSystem.DetachPerformer<SpentCardCostGA>();
        ActionSystem.DetachPerformer<RefillCardCostGA>();
        ActionSystem.UnsubscribeReaction<EnemyTurnGA>(EnemyTurnPostReaction, ReactionTiming.POST);
    }

    public bool HasEnoughCardCost(int cardCost)
    {
        return currentCardCost >= cardCost;
    }

    private IEnumerator SpendCardCostPerformer(SpentCardCostGA spentCardCostGA)
    {
        currentCardCost = Mathf.Max(0, currentCardCost - spentCardCostGA.Amount);
        cardCostUI.UpdateCardCostText(currentCardCost);
        yield return null;
    }

    private IEnumerator RefillCardCostPerformer(RefillCardCostGA refillCardCostGA)
    {
        currentCardCost = MAX_CARDCOST;
        cardCostUI.UpdateCardCostText(currentCardCost);
        yield return null;
    }

    private void EnemyTurnPostReaction(EnemyTurnGA enemyTurnGA)
    {
        RefillCardCostGA refillCardCostGA = new();
        ActionSystem.Instance.AddReaction(refillCardCostGA);
    }
}
