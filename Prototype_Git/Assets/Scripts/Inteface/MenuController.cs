using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject configurationPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        configurationPanel.SetActive(false);    
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Configuration() 
    {
        configurationPanel.SetActive(true);
    }


    // Update is called once per frame
    public void Exit()
    {
        Debug.Log("Fechou");
        Application.Quit();
    }
}
