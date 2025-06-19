using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public void MenuInicial() 
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }
}
