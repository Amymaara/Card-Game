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
        ActionSystem.AttachPerformer<RephraseGA>(RephrasePerformer);
    }

    private void OnDisable()
    {
        ActionSystem.DetachPerformer<ShiftMeterGA>();
        ActionSystem.DetachPerformer<RephraseGA>();
    }

    private IEnumerator ShiftMeterPerformer(ShiftMeterGA action)
    {
        
        CardType cardType = CurrentCardContext.CurrentType;

        float multiplier = effectivenessSystem.GetMultiplier(CurrentCardContext.CurrentType);
        float finalAmount = action.Amount * multiplier;

        meter.ShiftMeter(finalAmount);

        Debug.Log(effectivenessSystem.GetFeedback(multiplier, action.CardType));

        string feedback = effectivenessSystem.GetFeedback(multiplier, CurrentCardContext.CurrentType);
        feedbackUI.ShowFeedback(feedback);

        if (feedback == "Effective")
            npcTextUI.ShowText("That’s a good point.");
        else if (feedback == "Ineffective")
            npcTextUI.ShowText("That tone is unacceptable.");
        else
            npcTextUI.ShowText("I see what you’re saying.");

        yield return null;
    }

    private IEnumerator RephrasePerformer(RephraseGA action)
    {
        float last = meter.LastShiftAmount;

        if (last < 0)
        {
            // undo the negative effect
            meter.ShiftMeter(-last);

            feedbackUI.ShowFeedback("Recovered");
            npcTextUI.ShowText("You quickly correct yourself.");
        }
        else
        {
            // small bonus if no mistake
            meter.ShiftMeter(action.FallbackAmount);

            feedbackUI.ShowFeedback("Adjusted");
            npcTextUI.ShowText("You refine your wording.");
        }

        yield return null;
    }
}