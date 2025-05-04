using System;
using UnityEngine;
using UnityEngine.Audio;


public class InteractableObject : MonoBehaviour
{
    [SerializeField] private AudioData musicData;
    [SerializeField] private AudioSettings musicSettings;
    [SerializeField] private AudioSettings sfxSettings;
    [SerializeField] private AudioData sfxData;

    public static event Action<AudioMixerGroup, AudioClip> OnCollisionMusic;
    public static event Action OnExitSFX;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollisionMusic?.Invoke(musicSettings.AudioMixerGroup, musicData.AudioClip);
            OnCollisionMusic?.Invoke(sfxSettings.AudioMixerGroup, sfxData.AudioClip);
            FadeManager.Instance.FadeInFadeOut();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollisionMusic?.Invoke(sfxSettings.AudioMixerGroup, sfxData.AudioClip);
            OnExitSFX?.Invoke();
            FadeManager.Instance.FadeInFadeOut();
        }
    }
}