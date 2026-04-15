using UnityEngine;

public class InteractionMeterSystem : MonoBehaviour
{

    [SerializeField] private float minValue = -100f;
    [SerializeField] private float maxValue = 100f;
    [SerializeField] private WinLoseUI winLoseUI;
    [SerializeField] private InteractionMeterUI interactionMeterUI;
    public float LastShiftAmount { get; private set; }

    public float CurrentValue { get; private set; } = 0f;

    public void ShiftMeter(float amount)
    {
        CurrentValue += amount;
        CurrentValue = Mathf.Clamp(CurrentValue, minValue, maxValue);

        if (interactionMeterUI != null)
            interactionMeterUI.FlashShift(amount);

        Debug.Log("Meter: " + CurrentValue);

        CheckWinLose();
    }

    private void CheckWinLose()
    {
        if (CurrentValue >= maxValue)
        {
            Debug.Log("PLAYER WINS");
            if (winLoseUI != null)
                winLoseUI.ShowWin();
        }
        else if (CurrentValue <= minValue)
        {
            Debug.Log("PLAYER LOSES");
            if (winLoseUI != null)
                winLoseUI.ShowLose();
        }
    }

}
