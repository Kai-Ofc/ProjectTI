using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public GameObject player;
    public LifeController life;
    public AudioClip powerupSFX;
    private AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        life = player.GetComponent<LifeController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && life.currentLife < 5)
        {
            life.Heal(1);
            audioSource.PlayOneShot(powerupSFX);
            Destroy(gameObject);
        }
    }
}
