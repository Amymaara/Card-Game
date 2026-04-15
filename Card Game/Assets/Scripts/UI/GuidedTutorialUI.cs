using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class GuidedTutorialUI : MonoBehaviour, IPointerClickHandler
{
    [System.Serializable]
    public class TutorialStep
    {
        [TextArea(2, 5)]
        public string text;

        public RectTransform target;

        public Vector2 arrowOffset = new Vector2(0f, 100f);

        public bool showArrow = true;

        public float arrowRotation = 0f;
    }

    [Header("UI References")]
    [SerializeField] private GameObject panel;
    [SerializeField] private TMP_Text tutorialText;
    [SerializeField] private RectTransform arrow;

    [Header("Tutorial Steps")]
    [SerializeField] private TutorialStep[] steps;

    private int currentStepIndex = 0;

    private void Start()
    {
        if (steps == null || steps.Length == 0)
        {
            if (panel != null)
                panel.SetActive(false);

            return;
        }

        if (panel != null)
            panel.SetActive(true);

        Time.timeScale = 0f;
        ShowCurrentStep();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        currentStepIndex++;

        if (currentStepIndex >= steps.Length)
        {
            EndTutorial();
            return;
        }

        ShowCurrentStep();
    }

    private void ShowCurrentStep()
    {
        TutorialStep step = steps[currentStepIndex];

        if (tutorialText != null)
            tutorialText.text = step.text;

        if (arrow == null)
            return;

        bool shouldShowArrow = step.showArrow && step.target != null;
        arrow.gameObject.SetActive(shouldShowArrow);

        if (!shouldShowArrow)
            return;

        arrow.position = step.target.position + (Vector3)step.arrowOffset;
        arrow.rotation = Quaternion.Euler(0f, 0f, step.arrowRotation);
    }

    private void EndTutorial()
    {
        if (panel != null)
            panel.SetActive(false);

        Time.timeScale = 1f;
    }
}