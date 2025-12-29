using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Singleton instance for global access
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
        // Ensure only one instance exists (singleton pattern)
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        // Persist this object across scene loads
        DontDestroyOnLoad(gameObject);

        // Start music once
        if (musicSource != null && !musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }

    // Play the win sound effect
    public void PlayWin()
    {
        if (winClip != null)
            sfxSource.PlayOneShot(winClip);
    }

    // Play the lose sound effect
    public void PlayLose()
    {
        if (loseClip != null)
            sfxSource.PlayOneShot(loseClip);
    }

    // Play the star collection sound effect
    public void PlayStar()
    {
        if (starClip != null)
            sfxSource.PlayOneShot(starClip);
    }
}
