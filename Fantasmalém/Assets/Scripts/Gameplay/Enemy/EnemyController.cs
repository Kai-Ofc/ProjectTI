using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{

    public GameObject follow;
    public float distance;

    public float moveSpeed = 10.0f;

    public bool land = false;

    public PlayerController playerController;
    public SpawnerController spawner;

    public GunController gun;
    float timer;
    public float time;

    public GameObject hitParticle;
    public int life;
    public int damage;

    public bool bossDeath;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        land = false;
        follow = GameObject.FindGameObjectWithTag("Player");
        spawner = FindAnyObjectByType<SpawnerController>();
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
        spawner.Kills();
        Destroy(this.gameObject);
    }

    public void BossDeath()
    {
        if (this.gameObject.tag == "Boss")
        {
            bossDeath = true;
            Destroy(this.gameObject);
        }
    }

    public void HitInstance()
    {
        GameObject hit = Instantiate(hitParticle, this.transform.position, Quaternion.identity);
        Destroy(hit, 1f);
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
            HitInstance();

            if (life <= 0)
            {
                BossDeath();
                Death();
            }

        }

        if (other.gameObject.tag == "SuperShot")
        {
            life -= playerController.damage * 5;

            if (life <= 0)
            {
                BossDeath();
                Death();
            }

        }
    }
}
