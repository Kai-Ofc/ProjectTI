using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public LifeController life;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && life.currentLife < 4)
        {
            Destroy(this.gameObject);
        }
    }
}
