using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundAudioSource;
    public AudioSource sfxAudioSource;
    public Slider backgroundVolumeSlider;
    public Slider sfxVolumeSlider;
    public float fadeDuration = 1.0f;

    void Start()
    {
        if (backgroundAudioSource == null || sfxAudioSource == null)
        {
            Debug.LogError("Please assign AudioSources in the inspector.");
            return;
        }

        if (backgroundVolumeSlider != null)
        {
            backgroundVolumeSlider.onValueChanged.AddListener(SetBackgroundVolume);
            SetBackgroundVolume(backgroundVolumeSlider.value);
        }

        if (sfxVolumeSlider != null)
        {
            sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
            SetSFXVolume(sfxVolumeSlider.value);
        }

        Button[] buttons = FindObjectsOfType<Button>();
        foreach (Button button in buttons)
        {
            ButtonSFX buttonSFX = button.GetComponent<ButtonSFX>();
            if (buttonSFX != null)
            {
                button.onClick.AddListener(() => PlaySFX(buttonSFX.sfxClip));
            }
        }
    }

    public void SetBackgroundVolume(float volume)
    {
        float adjustedVolume = volume / 100f; // Chuyển đổi từ 0-100 thành 0-1
        StartCoroutine(FadeVolume(backgroundAudioSource, adjustedVolume, fadeDuration));
    }

    public void SetSFXVolume(float volume)
    {
        float adjustedVolume = volume / 100f; // Chuyển đổi từ 0-100 thành 0-1
        sfxAudioSource.volume = adjustedVolume;
    }

    public void PlaySFX(AudioClip clip)
    {
        if (sfxAudioSource != null && clip != null)
        {
            sfxAudioSource.PlayOneShot(clip);
        }
    }

    private IEnumerator FadeVolume(AudioSource audioSource, float targetVolume, float duration)
    {
        float startVolume = audioSource.volume;
        float time = 0;

        while (time < duration)
        {
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        audioSource.volume = targetVolume;
    }
}
