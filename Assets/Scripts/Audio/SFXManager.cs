using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXManager : MonoBehaviour
{
    public AudioSource sfxAudioSource;
    public Slider sfxVolumeSlider;
    public float fadeDuration = 1.0f;

    void Start()
    {
        if (sfxAudioSource == null)
        {
            Debug.LogError("Please assign the SFX AudioSource in the inspector.");
            return;
        }

        if (sfxVolumeSlider != null)
        {
            sfxVolumeSlider.onValueChanged.AddListener(SetSFXVolume);
            SetSFXVolume(sfxVolumeSlider.value);
        }
    }

    public void SetSFXVolume(float volume)
    {
        float adjustedVolume = volume / 100f; // Chuyển đổi từ 0-100 thành 0-1
        StartCoroutine(FadeVolume(sfxAudioSource, adjustedVolume, fadeDuration));
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
