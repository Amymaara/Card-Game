using UnityEngine;

public enum SoundType
{
    CardPlay,
    ButtonClick,
    Positive,
    Negative,
    Win,
    Lose
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource audioSource;

    [Header("Clips")]
    [SerializeField] private AudioClip cardPlay;
    [SerializeField] private AudioClip buttonClick;
    [SerializeField] private AudioClip positive;
    [SerializeField] private AudioClip negative;
    [SerializeField] private AudioClip win;
    [SerializeField] private AudioClip lose;

    private void Awake()
    {
        Instance = this;
    }

    public void PlaySound(SoundType sound, float volume = 2f)
    {
        AudioClip clip = GetClip(sound);

        if (clip == null)
        {
            Debug.LogWarning("No clip found for " + sound);
            return;
        }

        StartCoroutine(PlayLimited(clip, volume, 2f));
    }

    private System.Collections.IEnumerator PlayLimited(AudioClip clip, float volume, float duration)
    {
        GameObject temp = new GameObject("TempAudio");
        AudioSource source = temp.AddComponent<AudioSource>();

        source.clip = clip;
        source.volume = volume;
        source.Play();

        yield return new WaitForSeconds(duration);

        source.Stop();
        Destroy(temp);
    }

    private AudioClip GetClip(SoundType sound)
    {
        switch (sound)
        {
            case SoundType.CardPlay: return cardPlay;
            case SoundType.ButtonClick: return buttonClick;
            case SoundType.Positive: return positive;
            case SoundType.Negative: return negative;
            case SoundType.Win: return win;
            case SoundType.Lose: return lose;
            default: return null;
        }
    }
}