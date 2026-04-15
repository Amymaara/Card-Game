using System.Collections;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{
    [SerializeField] private InteractionMeterSystem meter;
    [SerializeField] private EffectivenessSystem effectivenessSystem;

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

        yield return null;
    }
}