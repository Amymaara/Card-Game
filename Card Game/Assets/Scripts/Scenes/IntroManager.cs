using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroManager : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private int index = 0;
    private float nextInputTime;

    private string[] lines = new string[]
    {
        "You enter the office...",
        "Your boss is waiting.",
        "This conversation will decide everything."
    };

    private void Start()
    {
        text.text = lines[index];
        nextInputTime = Time.time + 0.2f;
    }

    private void Update()
    {
        if (Time.time < nextInputTime) return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            AdvanceLine();
            nextInputTime = Time.time + 0.2f;
        }
    }

    private void AdvanceLine()
    {
        index++;

        if (index >= lines.Length)
        {
            SceneManager.LoadScene("SampleScene");
            return;
        }

        text.text = lines[index];
    }
}