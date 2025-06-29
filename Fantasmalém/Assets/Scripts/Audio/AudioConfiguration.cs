using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioConfiguration : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider musicVolumeSlider;

    public Slider sfxVolumeSlider;

    void Start()
    {
        PlayerPrefs.DeleteAll();
        GetComponent<AudioSource>().ignoreListenerPause = false;

        musicVolumeSlider.minValue = 0.01f;
        musicVolumeSlider.maxValue = 10f;

        sfxVolumeSlider.minValue = 0.01f;
        sfxVolumeSlider.maxValue = 10f;

        musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);

        sfxVolumeSlider.onValueChanged.AddListener(OnSFXVolumeChanged);;

        if (!PlayerPrefs.HasKey("MusicVolume"))
            PlayerPrefs.SetFloat("MusicVolume", 1f);

        if (!PlayerPrefs.HasKey("SFXVolume"))
            PlayerPrefs.SetFloat("SFXVolume", 1f);

        PlayerPrefs.Save();
    }

    public void InitializeAudioSettings()
    {
        float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);

        musicVolumeSlider.value = savedMusicVolume;

        float musicVolumeDB = LinearToDecibel(savedMusicVolume);
        audioMixer.SetFloat("MusicVolume", musicVolumeDB);

        float savedSFXVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

        sfxVolumeSlider.value = savedSFXVolume;

        float sfxVolumeDB = LinearToDecibel(savedSFXVolume);
        audioMixer.SetFloat("SFXVolume", sfxVolumeDB);
    }

    public void OnMusicVolumeChanged(float volume)
    {
        float dB = LinearToDecibel(volume);
        audioMixer.SetFloat("MusicVolume", dB);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    public void OnSFXVolumeChanged(float volume)
    {
        float dB = LinearToDecibel(volume);
        audioMixer.SetFloat("SFXVolume", dB);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    public float LinearToDecibel(float linear)
    {
        linear = Mathf.Clamp(linear, 0.01f, 1f);
        return Mathf.Log10(linear) * 20f;
    }
}
