﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public AudioSource backgroundAudioSource;
    public Slider backgroundVolumeSlider;
    public float fadeDuration = 1.0f;

    void Start()
    {
        if (backgroundAudioSource == null)
        {
            Debug.LogError("Please assign the Background AudioSource in the inspector.");
            return;
        }

        if (backgroundVolumeSlider != null)
        {
            backgroundVolumeSlider.onValueChanged.AddListener(SetBackgroundVolume);
            SetBackgroundVolume(backgroundVolumeSlider.value);
        }
    }

    public void SetBackgroundVolume(float volume)
    {
        float adjustedVolume = volume / 100f; // Chuyển đổi từ 0-100 thành 0-1
        StartCoroutine(FadeVolume(backgroundAudioSource, adjustedVolume, fadeDuration));
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
