using UnityEngine;
using UnityEngine.UI;

public class ConfigurationPanelController : MonoBehaviour
{
    public GameObject configurationPanel;
    public Toggle musicToggle, tutorialToggle;
    public Button exitButton;
    public Slider volumeSlider, fontSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void MusicSettings() 
    {
        if (musicToggle.isOn == true)
        {
            volumeSlider.enabled = true;
        }
        else 
        {
            volumeSlider.enabled = false;
            volumeSlider.value = 0;
        }
    }

    public void ExitButton() 
    {
        configurationPanel.SetActive(false);
    }


}
