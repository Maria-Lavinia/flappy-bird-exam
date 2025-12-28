using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [Header("Sources")]
    public AudioSource sfxSource;
    public AudioSource musicSource;

    [Header("Clips")]
    public AudioClip winClip;
    public AudioClip loseClip;
    public AudioClip starClip;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        // Start music once
        if (musicSource != null && !musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }

    public void PlayWin()
    {
        if (winClip != null)
            sfxSource.PlayOneShot(winClip);
    }

    public void PlayLose()
    {
        if (loseClip != null)
            sfxSource.PlayOneShot(loseClip);
    }

    public void PlayStar()
    {
        if (starClip != null)
            sfxSource.PlayOneShot(starClip);
    }
}
