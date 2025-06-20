using UnityEngine;

public class PlayerShootingSound : MonoBehaviour
{
    public AudioClip tiroSimples;
    public GameObject tiroSimplesPrefab;
    public Transform tiroSimplesfirePoint;
    public AudioClip tiroLaser;
    public GameObject tiroLaserPrefab;
    public Transform tiroLaserfirePoint;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            ShootLaser();
        }
    }

    void Shoot()
    {
        audioSource.PlayOneShot(tiroSimples);
    }
    
    void ShootLaser() {
        audioSource.PlayOneShot(tiroLaser);
    }
}
