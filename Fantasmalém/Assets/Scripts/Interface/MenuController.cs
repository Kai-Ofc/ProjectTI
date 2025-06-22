using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject configurationPanel;
    public GameObject grimorioPanel;
    bool isPaused;
    bool grimorioOpen;

    public void Start()
    {
        configurationPanel.SetActive(false);
        grimorioPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Update()
    {
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
    {  if (isPaused == true)
        {
            configurationPanel.SetActive(false);
            Time.timeScale = 1.0f;
            isPaused = false;
            return;
        }

        if(isPaused == false)
        {
            isPaused = true;
            configurationPanel.SetActive(true);
            Time.timeScale = 0f;
            return;
        }

        Debug.Log(isPaused);
    }

    public void GrimorioPanel()
    {
        grimorioPanel.SetActive(true);
    }

    public void Grimorio()
    {
        if (grimorioOpen == true)
        {
            grimorioPanel.SetActive(false);
            Time.timeScale = 1.0f;
            grimorioOpen = false;
            return;
        }

        if(grimorioOpen == false)
        {
            grimorioOpen = true;
            grimorioPanel.SetActive(true);
            Time.timeScale = 0f;
            return;
        }

        Debug.Log(grimorioOpen);
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
