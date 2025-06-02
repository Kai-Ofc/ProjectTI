using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject configurationPanel;
    bool isPaused;

    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        configurationPanel.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        { 
            Pause();
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
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
            Cursor.lockState = CursorLockMode.Locked;
            configurationPanel.SetActive(false);
            Time.timeScale = 1.0f;
            isPaused = false;
            return;
        }

        if(isPaused == false)
        {
            Cursor.lockState = CursorLockMode.None;
            isPaused = true;
            configurationPanel.SetActive(true);
            Time.timeScale = 0f;
            return;
        }

        Debug.Log(isPaused);
      
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
