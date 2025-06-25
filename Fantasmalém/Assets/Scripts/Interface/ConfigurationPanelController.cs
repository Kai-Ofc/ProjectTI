using UnityEngine;
using UnityEngine.UI;

public class ConfigurationPanelController : MonoBehaviour
{
    public GameObject configurationPanel;
    public Toggle musicToggle, effectToggle;
    public Button exitButton;
    public Slider volumeSlider, effectSlider;
    public GameObject grimorioPanel;
    public GrimorioPanel grimorio;
    bool isPaused;
    bool grimorioOpen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void MusicSettings() 
    {
        if (musicToggle.isOn == true)
        {
            volumeSlider.enabled = true;
            volumeSlider.value = -15;
        }
        else 
        {
            volumeSlider.enabled = false;
            volumeSlider.value = -40;
        }

        if (effectToggle.isOn == true)
        {
            effectSlider.enabled = true;
            effectSlider.value = -15;
        }
        else
        {
            effectSlider.enabled = false;
            effectSlider.value = -40;
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
        }
        else
        {
            if (!isPaused)
                Time.timeScale = 1.0f;
        }

        Debug.Log("Grimório aberto? " + grimorioOpen);
    }

    public void ExitButton() 
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        Debug.Log("Despausou");
        configurationPanel.SetActive(false);
    }


}
