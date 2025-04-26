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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject); ;
        }
    }
}
