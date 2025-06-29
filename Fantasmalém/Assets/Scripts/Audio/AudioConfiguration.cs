using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioConfiguration : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider musicVolumeSlider;
    //public Toggle musicToggle;

    public Slider sfxVolumeSlider;
    //public Toggle sfxToggle;

    void Start()
    {
        PlayerPrefs.DeleteAll();
        GetComponent<AudioSource>().ignoreListenerPause = false;

        musicVolumeSlider.minValue = 0.01f;
        musicVolumeSlider.maxValue = 1f;

        sfxVolumeSlider.minValue = 0.01f;
        sfxVolumeSlider.maxValue = 1f;

        musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        //musicToggle.onValueChanged.AddListener(OnMusicToggleChanged);

        sfxVolumeSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
        //sfxToggle.onValueChanged.AddListener(OnSFXToggleChanged);

        if (!PlayerPrefs.HasKey("MusicVolume"))
            PlayerPrefs.SetFloat("MusicVolume", 1f);

        if (!PlayerPrefs.HasKey("SFXVolume"))
            PlayerPrefs.SetFloat("SFXVolume", 1f);

        if (!PlayerPrefs.HasKey("MusicEnabled"))
            PlayerPrefs.SetInt("MusicEnabled", 1);

        if (!PlayerPrefs.HasKey("SFXEnabled"))
            PlayerPrefs.SetInt("SFXEnabled", 1);

        PlayerPrefs.Save();
    }

    public void InitializeAudioSettings()
    {
        float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        //bool musicEnabled = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;

        musicVolumeSlider.value = savedMusicVolume;
       // musicToggle.isOn = musicEnabled;

        //float musicVolumeDB = musicEnabled ? LinearToDecibel(savedMusicVolume) : -80f;
        float musicVolumeDB = LinearToDecibel(savedMusicVolume);
        audioMixer.SetFloat("MusicVolume", musicVolumeDB);

        float savedSFXVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        //bool sfxEnabled = PlayerPrefs.GetInt("SFXEnabled", 1) == 1;

        sfxVolumeSlider.value = savedSFXVolume;
        //sfxToggle.isOn = sfxEnabled;

        //float sfxVolumeDB = sfxEnabled ? LinearToDecibel(savedSFXVolume) : -80f;
        float sfxVolumeDB = LinearToDecibel(savedSFXVolume);
        audioMixer.SetFloat("SFXVolume", sfxVolumeDB);
    }

    public void OnMusicVolumeChanged(float volume)
    {
        float dB = LinearToDecibel(volume);
        audioMixer.SetFloat("MusicVolume", dB);
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    //public void OnMusicToggleChanged(bool isOn)
    //{
    //    float volume = musicVolumeSlider.value;
    //    float dB = isOn ? LinearToDecibel(volume) : -80f;

    //    audioMixer.SetFloat("MusicVolume", dB);
    //    PlayerPrefs.SetInt("MusicEnabled", isOn ? 1 : 0);
    //}

    public void OnSFXVolumeChanged(float volume)
    {
        float dB = LinearToDecibel(volume);
        audioMixer.SetFloat("SFXVolume", dB);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    //public void OnSFXToggleChanged(bool isOn)
    //{
    //    float volume = sfxVolumeSlider.value;
    //    float dB = isOn ? LinearToDecibel(volume) : -80f;

    //    audioMixer.SetFloat("SFXVolume", dB);
    //    PlayerPrefs.SetInt("SFXEnabled", isOn ? 1 : 0);
    //}

    public float LinearToDecibel(float linear)
    {
        linear = Mathf.Clamp(linear, 0.01f, 1f);
        return Mathf.Log10(linear) * 20f;
    }
}
