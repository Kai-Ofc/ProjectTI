using UnityEngine;

public class ShotPowerUp : MonoBehaviour
{
    public GameObject player;
    public PowerUpController powerUpController;
    public AudioClip powerupSFX;
    private AudioSource sfxSource;

    public void Start()
    {
        sfxSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        powerUpController = player.GetComponent<PowerUpController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            powerUpController.SetSizeShot();
            
            if (sfxSource != null && powerupSFX != null)
                sfxSource.PlayOneShot(powerupSFX);
                
            Destroy(gameObject);
        }
    }
}
