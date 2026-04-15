using System.Collections;
using TMPro;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField] private InteractionMeterSystem meter;
    [SerializeField] private EffectivenessSystem effectivenessSystem;
    [SerializeField] private FeedbackUiText feedbackUI;
    [SerializeField] private NpcTextUI npcTextUI;

   
    private void OnEnable()
    {
        ActionSystem.AttachPerformer<ShiftMeterGA>(ShiftMeterPerformer);
    }

    private void OnDisable()
    {
        ActionSystem.DetachPerformer<ShiftMeterGA>();
    }

    private IEnumerator ShiftMeterPerformer(ShiftMeterGA action)
    {
        
        CardType cardType = CurrentCardContext.CurrentType;

        float multiplier = effectivenessSystem.GetMultiplier(cardType);
        float finalAmount = action.Amount * multiplier;

        meter.ShiftMeter(finalAmount);

        Debug.Log(effectivenessSystem.GetFeedback(multiplier));

        string feedback = effectivenessSystem.GetFeedback(multiplier);
        feedbackUI.ShowFeedback(feedback);

        if (feedback == "Effective")
            npcTextUI.ShowText("That’s a good point.");
        else if (feedback == "Ineffective")
            npcTextUI.ShowText("That tone is unacceptable.");
        else
            npcTextUI.ShowText("I see what you’re saying.");

        yield return null;
    }
}