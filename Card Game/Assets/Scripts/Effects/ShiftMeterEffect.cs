using UnityEngine;

public class ShiftMeterEffect : Effect
{
    [SerializeField] private int baseAmount;

    public override GameAction GetGameAction()
    {
        return new ShiftMeterGA(baseAmount);
    }
}