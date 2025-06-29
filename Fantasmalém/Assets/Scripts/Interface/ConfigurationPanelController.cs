using UnityEngine;
using UnityEngine.UI;

public class ConfigurationPanelController : MonoBehaviour
{
    public GameObject configurationPanel;
    public Button exitButton;

    public void ExitButton() 
    {
        Time.timeScale = 1.0f;
        Debug.Log("Despausou");
        configurationPanel.SetActive(false);
    }
}
