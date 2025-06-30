using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject configurationPanel;
    public GameObject bossLifeBar;
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
    PlayerShootingSound shootingSound = Object.FindFirstObjectByType<PlayerShootingSound>();

    if (isPaused)
    {
        Debug.Log("Despausou");
        configurationPanel.SetActive(false);
        Time.timeScale = 1.0f;
        isPaused = false;
        shootingSound.UnSetSFXMuted();
        audioConfiguration.InitializeAudioSettings();

        if (bossLifeBar != null)
        bossLifeBar.SetActive(true);

        return;
    }

    if (!isPaused)
    {
        configurationPanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        
        if (bossLifeBar != null)
        bossLifeBar.SetActive(false);

        shootingSound.SetSFXMuted();
        return;
    }
}


    public void RestoreAudioSettings()
    {
        float savedMusicVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        float musicVolumeDB = audioConfiguration.LinearToDecibel(savedMusicVolume);
        audioConfiguration.audioMixer.SetFloat("MusicVolume", musicVolumeDB);

        float savedSFXVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);
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