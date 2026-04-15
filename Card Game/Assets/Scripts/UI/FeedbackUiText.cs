using System.Collections;
using TMPro;
using UnityEngine;

public class FeedbackUiText : MonoBehaviour
{
    [SerializeField] private TMP_Text feedbackText;

    private void Start()
    {
        ClearFeedback();
    }

    public void ShowFeedback(string message)
    {
        StopAllCoroutines();

        feedbackText.text = message;

        switch (message)
        {
            case "Effective":
                feedbackText.color = Color.green;
                break;
            case "Ineffective":
                feedbackText.color = Color.red;
                break;
            default:
                feedbackText.color = Color.yellow;
                break;
        }

        StartCoroutine(ClearAfterDelay());
    }

    private IEnumerator ClearAfterDelay()
    {
        yield return new WaitForSeconds(1.5f);
        ClearFeedback();
    }

    public void ClearFeedback()
    {
        feedbackText.text = "";
    }

}
