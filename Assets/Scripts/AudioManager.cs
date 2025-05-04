using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [SerializeField] private AudioSettings[] audioSettings;
    [SerializeField] private AudioSource musicSource;

    private float[] _savedVolumes;
    private int _dataLength;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);

        _dataLength = audioSettings.Length;

        _savedVolumes = new float[_dataLength];
    }

    private void OnEnable()
    {
        for (int i = 0; i < _dataLength; i++)
        {
            _savedVolumes[i] = audioSettings[i].VolumeScaled;
        }
        InteractableObject.OnExitSFX += AudioStop;
    }

    private void OnDisable()
    {
        InteractableObject.OnExitSFX -= AudioStop;
    }

    public void RevertChanges()
    {
        for (int i = 0; i < _dataLength; i++)
        {
            audioSettings[i].UpdateVolume(_savedVolumes[i]);
        }
    }

    public void ApplyChange()
    {
        for (int i = 0; i < _dataLength; i++)
        {
            audioSettings[i].SaveDataFile();

            _savedVolumes[i] = audioSettings[i].VolumeScaled;
        }
    }
    public void AudioStop()
    {
        musicSource.Stop();
    }
}