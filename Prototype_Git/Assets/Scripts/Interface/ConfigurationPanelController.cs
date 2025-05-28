using UnityEngine;
using UnityEngine.UI;

public class ConfigurationPanelController : MonoBehaviour
{
    public GameObject configurationPanel;
    public Toggle musicToggle, effectToggle, tutorialToggle;
    public Button exitButton;
    public Slider volumeSlider, effectSlider, fontSlider;
    
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

    public void ExitButton() 
    {
        configurationPanel.SetActive(false);
    }


}
