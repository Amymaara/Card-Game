using UnityEngine;

public class EffectivenessSystem : MonoBehaviour
{
    public float GetMultiplier(CardType cardType)
    {
        // TEMP: Office – Boss example
        switch (cardType)
        {
            case CardType.Professional:
                return 1.5f; // effective

            case CardType.Aggressive:
                return -0.5f; // ineffective

            case CardType.Emotional:
                return 1f; // neutral

            default:
                return 1f;
        }
    }

    public string GetFeedback(float multiplier)
    {
        if (multiplier > 1f) return "Effective";
        if (multiplier < 1f) return "Ineffective";
        return "Neutral";
    }
}