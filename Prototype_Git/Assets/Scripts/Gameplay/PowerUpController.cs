using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public GameObject player;
    public LifeController life;
    public MeshRenderer[] sprites;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        life = player.GetComponent<LifeController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && sprites[0] && life.currentLife < 4)
        {
            life.Heal(1);
            Debug.Log("Vida depois do powerUp: " + life.currentLife);
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "Player" && sprites[1] && life.currentLife < 4)
        {
            Destroy(this.gameObject, 5f);
        }
    }
}
