using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InteractionMeterUI : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private Image fillImage;
    [SerializeField] private InteractionMeterSystem meterSystem;

    [Header("Colours")]
    [SerializeField] private Color neutralColor = Color.white;
    [SerializeField] private Color positiveColor = Color.green;
    [SerializeField] private Color negativeColor = Color.red;

    [Header("Flash Timing")]
    [SerializeField] private float flashDuration = 0.4f;

    private Coroutine flashRoutine;

    private void Start()
    {
        UpdateMeterValue();
        fillImage.color = neutralColor;
    }

    private void Update()
    {
        UpdateMeterValue();
    }

    public void FlashShift(float amount)
    {
        if (flashRoutine != null)
            StopCoroutine(flashRoutine);

        flashRoutine = StartCoroutine(FlashRoutine(amount));
    }

    private IEnumerator FlashRoutine(float amount)
    {
        if (amount > 0)
            fillImage.color = positiveColor;
        else if (amount < 0)
            fillImage.color = negativeColor;
        else
            fillImage.color = neutralColor;

        yield return new WaitForSeconds(flashDuration);

        fillImage.color = neutralColor;
        flashRoutine = null;
    }

    private void UpdateMeterValue()
    {
        float normalized = Mathf.InverseLerp(-100f, 100f, meterSystem.CurrentValue);
        slider.value = normalized;
    }
}
