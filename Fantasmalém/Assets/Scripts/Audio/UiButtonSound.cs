using UnityEngine;

public class UiButtonSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSound;

    public void PlayClickSound()
    {
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource não atribuído!");
            return;
        }

        if (!audioSource.enabled)
            audioSource.enabled = true;

        if (!audioSource.gameObject.activeInHierarchy)
            audioSource.gameObject.SetActive(true);

        audioSource.PlayOneShot(clickSound);
    }
}
