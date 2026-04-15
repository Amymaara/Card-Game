using UnityEngine;
using UnityEngine.UI;

public class InteractionMeterUI : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private InteractionMeterSystem meterSystem;

    private void Update()
    {
        float normalized = Mathf.InverseLerp(-100f, 100f, meterSystem.CurrentValue);
        slider.value = normalized;
    }
}
