using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject configurationPanel;
    public GameObject lifes;
    bool isPaused;

    public void Start()
    {
        configurationPanel.SetActive(false);
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

    public void Tutorial ()
    {
        SceneManager.LoadScene(5);
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
