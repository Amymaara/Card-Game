using UnityEngine;

public class SpentCardCostGA : GameAction
{
    public int Amount { get; set; }

    public SpentCardCostGA(int amount)
    {
        Amount = amount;
    }
}
