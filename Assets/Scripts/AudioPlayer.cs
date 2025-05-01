using UnityEngine;
using UnityEngine.Audio;


public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private ChannelPlayer musicPlayer;
    [SerializeField] private ChannelPlayer sfxPlayer;
    private void OnEnable()
    {
        InteractableObject.OnCollisionMusic += PlayPlayer;
    }

    private void OnDisable()
    {
        InteractableObject.OnCollisionMusic -= PlayPlayer;
    }

    private void PlayPlayer(AudioMixerGroup currentGroup, AudioClip currentAudioClip)
    {
        if (currentGroup == musicPlayer.PlayerChannel)
        {
            musicPlayer.PlayerClip(currentAudioClip);
        }
        else
        {
            sfxPlayer.PlayerClip(currentAudioClip);
        }
    }
}