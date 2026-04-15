using System.Collections;
using TMPro;
using UnityEngine;

public class NpcTextUI : MonoBehaviour
{
    [SerializeField] private TMP_Text npcText;

    private void Start()
    {
        ClearText();
    }

    public void ShowText(string message)
    {
        StopAllCoroutines();

        npcText.text = message;
        StartCoroutine(ClearAfterDelay());
    }

    private IEnumerator ClearAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        ClearText();
    }

    public void ClearText()
    {
        npcText.text = "";
    }
}
