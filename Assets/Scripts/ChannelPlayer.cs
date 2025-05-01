using UnityEngine;
using UnityEngine.Audio;


public class ChannelPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSettings audioSettings;

    public AudioMixerGroup PlayerChannel => audioSource.outputAudioMixerGroup;

    private void Awake()
    {
        audioSource.outputAudioMixerGroup = audioSettings.AudioMixerGroup;
    }

    public void PlayerClip(AudioClip clipToPlay)
    {
        audioSource.Stop();

        audioSource.clip = clipToPlay;

        audioSource.Play();
    }
}