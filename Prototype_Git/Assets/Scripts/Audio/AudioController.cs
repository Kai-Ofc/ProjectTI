using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    AudioMixer audioMixer;
    public AudioClip[] clips;
    public AudioSource audioSource;

    public Slider volumeSlider, effectSlider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudio(int indice) 
    { 
        audioSource.clip = clips[indice];
        audioSource.Play();
    }

    public void MudarVolume(int indice) 
    { 
        if(indice == 0) 
        {
            audioMixer.SetFloat("volVol", volumeSlider.value);
        }

        if (indice == 1)
        {
            audioMixer.SetFloat("effVOl", effectSlider.value);
        }
    }
}
