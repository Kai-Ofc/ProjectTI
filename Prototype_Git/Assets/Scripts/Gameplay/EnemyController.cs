using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{

    public GameObject follow;
    public float distance;

    public float moveSpeed = 10.0f;

    public bool land = false;

    public PlayerController playerController;

    public GunController gun;
    float timer;
    public float time;

    public int life;
    public int damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        land = false;
        follow = GameObject.FindGameObjectWithTag("Player");
        gun = GetComponent<GunController>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; 
        EnemyMovement();

        if (timer >= time) 
        {
            gun.Shoot();
            timer = 0;
        }
    }

    void EnemyMovement() 
    {
        transform.LookAt(follow.transform.position);

        if (land == true && playerController.camMovement != true)
        {
            Vector3 enemyMove = follow.transform.position + follow.transform.right * distance;
            enemyMove.y = transform.position.y;

            transform.position = Vector3.MoveTowards(transform.position, enemyMove , moveSpeed * Time.deltaTime);           
        }

    }

    public void PlayerReference( PlayerController playerRef) 
    {
        playerController = playerRef;
    }

    public void Death() 
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor") 
        {
            land = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Shot")
        {
            life -= playerController.damage;

            if (life <= 0)
            {
                Death();
            }

        }

        if (other.gameObject.tag == "SuperShot")
        {
            life -= playerController.damage * 2;

            if (life <= 0)
            {
                Death();
            }

        }
    }
}
