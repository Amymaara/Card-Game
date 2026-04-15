using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CombatantView : MonoBehaviour
{
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Image image;

    public int MaxHealth { get; private set; }

    public int CurrentHealth { get; private set; }

    protected void SetupBase(int health, Image sourceImage)
    {
        MaxHealth = CurrentHealth = health;
        image.sprite = sourceImage.sprite;
        UpdateHealthText();
    }

    private void UpdateHealthText()
    {
        healthText.text = "HP: " + CurrentHealth;
    }

}
