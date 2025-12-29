using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private Vector3 originalPos;
    private Coroutine shakeRoutine;

    // Stores the original camera position on initialization.
    private void Awake()
    {
        originalPos = transform.localPosition;
    }

    // Triggers a camera shake effect with specified parameters.
    // How long the shake lasts in seconds.
    /// the intensity of the shake.
    public void Shake(float duration = 0.15f, float magnitude = 0.1f)
    {
        // Stop any existing shake before starting a new one
        if (shakeRoutine != null)
            StopCoroutine(shakeRoutine);

        shakeRoutine = StartCoroutine(ShakeCoroutine(duration, magnitude));
    }

    // Coroutine that performs the camera shake animation.
    private IEnumerator ShakeCoroutine(float duration, float magnitude)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            // Generate random offset within magnitude bounds
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            transform.localPosition = originalPos + new Vector3(x, y, 0f);

            elapsed += Time.unscaledDeltaTime; // still shakes even if timescale becomes 0
            yield return null;
        }

        // Reset camera to original position
        transform.localPosition = originalPos;
        shakeRoutine = null;
    }
}
