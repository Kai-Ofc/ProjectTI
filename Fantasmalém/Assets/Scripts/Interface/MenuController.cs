using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject configurationPanel;
    public GameObject grimorioPanel;
    public GrimorioPanel grimorio;
    public bool isPaused;
    bool grimorioOpen;

    public void Start()
    {
        configurationPanel.SetActive(false);
        grimorioPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Update()
    {
        Debug.Log(isPaused);

        if (Input.GetKeyDown(KeyCode.Space)) 
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
    }

    public void Pause() 
    {
        if (grimorioOpen) return;

        if (isPaused == true)
        {
            configurationPanel.SetActive(false);
            Time.timeScale = 1.0f;
            isPaused = false;
            return;
        }

        if(isPaused == false)
        {
            configurationPanel.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
            return;
        }
    }

    public void Grimorio()
    {
        bool open = !grimorioPanel.activeSelf;
        grimorioPanel.SetActive(open);
        grimorioOpen = open; 

        if (open)
        {
            grimorio.ShowHistory();

            if (!isPaused)
                Time.timeScale = 0f;
        }
        else
        {
            if (!isPaused)
                Time.timeScale = 1.0f;
        }

        Debug.Log("Grimório aberto? " + grimorioOpen);
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