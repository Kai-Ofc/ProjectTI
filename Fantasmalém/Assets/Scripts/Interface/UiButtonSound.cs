using UnityEngine;

public class UiButtonSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSFX;

    public void PlayClickSound()
    {
        audioSource.PlayOneShot(clickSFX);
    }
}
