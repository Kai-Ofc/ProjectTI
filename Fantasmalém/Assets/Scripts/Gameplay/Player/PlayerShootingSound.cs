using UnityEngine;

public class PlayerShootingSound : MonoBehaviour
{
    public AudioClip tiroSimples;
    public GameObject tiroSimplesPrefab;
    public Transform tiroSimplesfirePoint;
    public AudioClip tiroLaser;
    public GameObject tiroLaserPrefab;
    public Transform tiroLaserfirePoint;

    public AudioSource sfxSource;

    void Start()
    {
        sfxSource = GetComponent<AudioSource>();
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
        sfxSource.PlayOneShot(tiroSimples);
    }

    void ShootLaser()
    {
        sfxSource.PlayOneShot(tiroLaser);
    }

    public void SetSFXMuted(bool muted)
    {
        sfxSource.volume = muted ? 0f : 1f;
    }
}

