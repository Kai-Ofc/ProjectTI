using UnityEngine;
using UnityEngine.UI;

public class ConfigurationPanelController : MonoBehaviour
{
    public GameObject configurationPanel;
    public Button exitButton;
    public GameObject grimorioPanel;
    public GrimorioPanel grimorio;
    bool isPaused;
    bool grimorioOpen;

    public void Grimorio()
    {
        bool open = !grimorioPanel.activeSelf;
        grimorioPanel.SetActive(open);
        grimorioOpen = open;

        if (open)
        {
            grimorio.ShowHistory();
        }
        else
        {
            if (!isPaused)
                Time.timeScale = 1.0f;
        }

        Debug.Log("Grimorio aberto? " + grimorioOpen);
    }

    public void ExitButton() 
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        Debug.Log("Despausou");
        configurationPanel.SetActive(false);
    }


}
