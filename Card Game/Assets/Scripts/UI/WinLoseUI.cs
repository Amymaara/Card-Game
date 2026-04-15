using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    //  Restart button
    public void RestartGame()
    {
        Time.timeScale = 1f; // unpause
        SceneManager.LoadScene("IntroScene");
    }

    //  Quit button
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

}