using UnityEngine;

public class RephraseEffect : Effect
{
    [SerializeField] private int fallbackAmount = 5;

    public override GameAction GetGameAction()
    {
        return new RephraseGA(fallbackAmount);
    }
}