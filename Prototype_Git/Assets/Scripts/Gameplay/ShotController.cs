using UnityEngine;

public class ShotController : MonoBehaviour
{

    public float speed = 20f;

    Vector3 vel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += vel * Time.deltaTime;
    }

    public void SetDirection(Vector3 direction) 
    {
        vel = direction * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag == "Shot" && other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }

        if (this.gameObject.tag == "EnemyShot" && other.gameObject.tag == "Player") 
        {
            Destroy(this.gameObject);
        }
        
        if (this.gameObject.tag == "EnemyShot" && other.gameObject.tag == "Block")
        {
            Destroy(this.gameObject);
        }

        if (this.gameObject.tag == "EnemyShot" && other.gameObject.tag == "PowerUp")
        {
            Destroy(this.gameObject);
        }


    }
}
