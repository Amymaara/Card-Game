using UnityEngine;

public class EndTurnButtonUI : MonoBehaviour
{
    public void OnClick()
    {
        SoundManager.Instance.PlaySound(SoundType.ButtonClick);

        EnemyTurnGA enemyTurnGA = new();
        ActionSystem.Instance.Perform(enemyTurnGA);
    }
}
