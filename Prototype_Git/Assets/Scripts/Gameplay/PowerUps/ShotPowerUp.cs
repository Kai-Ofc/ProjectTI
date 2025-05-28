using UnityEngine;

public class ShotPowerUp : MonoBehaviour
{
    public GameObject player;
    public PowerUpController powerUpController;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        powerUpController = player.GetComponent<PowerUpController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            powerUpController.SetSizeShot();
            Destroy(gameObject);
        }
    }
}
