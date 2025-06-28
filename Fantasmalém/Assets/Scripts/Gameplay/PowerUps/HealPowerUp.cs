using UnityEngine;

public class HealPowerUp : MonoBehaviour
{
    public GameObject player;
    public LifeController life;
    public AudioClip powerupSFX;
    private AudioSource sfxSource;

    public void Start()
    {
        sfxSource = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        life = player.GetComponent<LifeController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && life.currentLife < 5)
        {
            life.Heal(1);

            if (sfxSource != null && powerupSFX != null)
                sfxSource.PlayOneShot(powerupSFX);
                
            Destroy(gameObject);
        }
    }
}