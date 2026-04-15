using TMPro;
using UnityEngine;

public class WinLoseUI : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text resultText;

    public void ShowWin()
    {
        panel.SetActive(true);
        resultText.text = "You handled the situation well.";
    }

    public void ShowLose()
    {
        panel.SetActive(true);
        resultText.text = "You escalated the situation.";
    }
}