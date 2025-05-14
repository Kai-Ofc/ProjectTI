using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfigurationController : MonoBehaviour
{
    public  TextMeshProUGUI volumeValue;
    public Slider volumeSlider;
    public Toggle musicToggle;
    public Toggle tutorialToggle;

    public GameObject configurationPanel;

    public void VolumeSettings() 
    {
        if (musicToggle.isOn == false) 
        { 
            volumeSlider.enabled = false;
        }
        else if(musicToggle.isOn == true)
        {
            volumeSlider.enabled = true;
            volumeValue.text = volumeSlider.value.ToString();
        }
    }

    public void ExitButton() 
    { 
        configurationPanel.SetActive(false);
    }
}
