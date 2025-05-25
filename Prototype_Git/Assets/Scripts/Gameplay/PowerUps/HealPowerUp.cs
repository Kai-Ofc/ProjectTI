using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public GameObject player;
    public LifeController life;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        life = player.GetComponent<LifeController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && life.currentLife < 4)
        {
            life.Heal(1);
            Debug.Log("Vida depois do powerUp: " + life.currentLife);
            Destroy(this.gameObject);
        }
    }
}
