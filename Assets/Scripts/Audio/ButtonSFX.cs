using UnityEngine;
using UnityEngine.UI;

public class ButtonSFX : MonoBehaviour
{
    public AudioSource sfxAudioSource;
    public AudioClip sfxClip;

    void Start()
    {
        Button button = GetComponent<Button>();

        if (sfxAudioSource == null)
        {
            Debug.LogError("Please assign the SFX AudioSource in the inspector.");
            return;
        }

        button.onClick.AddListener(PlaySFX);
    }

    public void PlaySFX()
    {
        if (sfxAudioSource != null && sfxClip != null)
        {
            sfxAudioSource.PlayOneShot(sfxClip);
        }
    }
}
