using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public GameObject player;
    public PowerUpController powerUpController;
    public AudioClip powerupSFX;
    private AudioSource sfxSource;

    void Start()
    {
        sfxSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        powerUpController = player.GetComponent<PowerUpController>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && powerUpController.protecion != true)
        {
            powerUpController.StartShield();
            
            if (sfxSource != null && powerupSFX != null)
                sfxSource.PlayOneShot(powerupSFX);
                
            Destroy(gameObject, 0.35f);
        }
    }
}
