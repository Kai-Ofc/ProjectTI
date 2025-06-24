using UnityEngine;

public class ShotPowerUp : MonoBehaviour
{
    public GameObject player;
    public PowerUpController powerUpController;
    public AudioClip powerupSFX;
    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        powerUpController = player.GetComponent<PowerUpController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            powerUpController.SetSizeShot();
            audioSource.PlayOneShot(powerupSFX);
            Destroy(gameObject);
        }
    }
}
