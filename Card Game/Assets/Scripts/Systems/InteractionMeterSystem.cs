using UnityEngine;

public class InteractionMeterSystem : MonoBehaviour
{

    [SerializeField] private float minValue = -100f;
    [SerializeField] private float maxValue = 100f;
    [SerializeField] private WinLoseUI winLoseUI;

    public float CurrentValue { get; private set; } = 0f;

    public void ShiftMeter(float amount)
    {
        CurrentValue += amount;
        CurrentValue = Mathf.Clamp(CurrentValue, minValue, maxValue);

        Debug.Log("Meter: " + CurrentValue);

        CheckWinLose();
    }

    private void CheckWinLose()
    {
        if (CurrentValue >= maxValue)
        {
            Debug.Log("PLAYER WINS");
            winLoseUI.ShowWin();
        }
        else if (CurrentValue <= minValue)
        {
            Debug.Log("PLAYER LOSES");
            winLoseUI.ShowLose();
        }
    }

}
