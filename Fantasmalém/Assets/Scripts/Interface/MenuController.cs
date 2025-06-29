using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject configurationPanel;
    public AudioConfiguration audioConfiguration;
    public bool isPaused;

    public void Start()
    {
        configurationPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
        Time.timeScale = 1.0f;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
            Pause();
        }
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Configuration()
    {
        configurationPanel.SetActive(true);
        audioConfiguration.InitializeAudioSettings();
    }

    public void Pause() 
    {

        if (isPaused)
        {
            Debug.Log("Abriu");
            configurationPanel.SetActive(false);
            Time.timeScale = 1.0f;
            isPaused = false;
            //RestoreAudioSettings();
            audioConfiguration.InitializeAudioSettings();
            return;
        }

        if(!isPaused)
        {
            configurationPanel.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
            return;
        }
    }

    public void RestoreAudioSettings()
    {
        float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        //bool musicEnabled = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
        //float musicVolumeDB = musicEnabled ? audioConfiguration.LinearToDecibel(savedMusicVolume) : -80f;
        float musicVolumeDB = audioConfiguration.LinearToDecibel(savedMusicVolume);
        audioConfiguration.audioMixer.SetFloat("MusicVolume", musicVolumeDB);

        float savedSFXVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
        //bool sfxEnabled = PlayerPrefs.GetInt("SFXEnabled", 1) == 1;
        //float sfxVolumeDB = sfxEnabled ? audioConfiguration.LinearToDecibel(savedSFXVolume) : -80f;
        float sfxVolumeDB = audioConfiguration.LinearToDecibel(savedSFXVolume);
        audioConfiguration.audioMixer.SetFloat("SFXVolume", sfxVolumeDB);
    }

    public void Leave()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Debug.Log("Fechou");
        Application.Quit();
    }
}