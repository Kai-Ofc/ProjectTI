using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public GameObject player;
    public PowerUpController powerUpController;
    public AudioClip powerupSFX;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        powerUpController = player.GetComponent<PowerUpController>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && powerUpController.protecion != true)
        {
            powerUpController.StartShield();
            audioSource.PlayOneShot(powerupSFX);
            Destroy(gameObject, 0.4f);
        }
    }
}
