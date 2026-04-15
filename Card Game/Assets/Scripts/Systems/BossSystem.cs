using System.Collections;
using UnityEngine;

public class BossSystem : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private InteractionMeterSystem interactionMeterSystem;
    [SerializeField] private NpcTextUI npcTextUI;
    [SerializeField] private FeedbackUiText feedbackUI;

    [Header("Boss Turn")]
    [SerializeField] private int bossPressureAmount = -15;
    [SerializeField] private float delayBeforePressure = 2f;
    [SerializeField] private float delayAfterPressure = 1f;

    [Header("Boss Dialogue")]
    [SerializeField] private string[] bossIntroLines;
    [SerializeField] private string[] bossPressureLines;

    private void OnEnable()
    {
        ActionSystem.AttachPerformer<EnemyTurnGA>(EnemyTurnPerformer);
    }

    private void OnDisable()
    {
        ActionSystem.DetachPerformer<EnemyTurnGA>();
    }

    private IEnumerator EnemyTurnPerformer(EnemyTurnGA enemyTurnGA)
    {
        if (feedbackUI != null)
            feedbackUI.ShowFeedback("Boss Turn");

        if (npcTextUI != null)
            npcTextUI.ShowText(GetRandomLine(bossIntroLines, "Your boss cuts in sharply."));

        yield return new WaitForSeconds(delayBeforePressure);

        if (interactionMeterSystem != null)
            interactionMeterSystem.ShiftMeter(bossPressureAmount);

        if (npcTextUI != null)
            npcTextUI.ShowText(GetRandomLine(bossPressureLines, "This is not acceptable. Do better."));

        yield return new WaitForSeconds(delayAfterPressure);
    }

    private string GetRandomLine(string[] lines, string fallback)
    {
        if (lines == null || lines.Length == 0)
            return fallback;

        int index = Random.Range(0, lines.Length);
        return lines[index];
    }
}