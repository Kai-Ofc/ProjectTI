using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{

    public GameObject follow;
    public float distance;

    public float moveSpeed = 10.0f;

    public bool land = false;

    public PlayerController playerController;
    public PowerUpController powerUpController;
    public SpawnerController spawner;

    public GunController gun;
    float timer;
    public float time;

    public GameObject hitParticle;
    public int life;
    public int damage;

    //Boss
    public bool bossDeath;

    void Start()
    {
        land = false;
        follow = GameObject.FindGameObjectWithTag("Player");
        spawner = FindAnyObjectByType<SpawnerController>();
        powerUpController = FindAnyObjectByType<PowerUpController>();
        gun = GetComponent<GunController>();
    }

    void Update()
    {
        timer += Time.deltaTime; 
        EnemyMovement();

        if (timer >= time) 
        {
            if (this.gameObject.tag == "Boss")
            {
                gun.BossSuperShot();
                timer = 0;
           
            }
            else if (this.gameObject.tag == "Mimic") 
            {
                gun.MimicShoot();
                timer = 0;
            }
            else
            {
                gun.Shoot();
                timer = 0;
            }

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
        if (this.gameObject.tag == "Enemy" || this.gameObject.tag == "Mimic")
        {
            spawner.Kills();
            Destroy(this.gameObject);
        }
    }

    public void BossDeath()
    {
        if (this.gameObject.tag == "Boss")
        {
            bossDeath = true;
            SceneManager.LoadScene(4);
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
            if (powerUpController.bigShot == true)
            {
                life -= playerController.playerDamage * 2;
                HitInstance();
            }
            else 
            {
                life -= playerController.playerDamage;
                HitInstance();
            }

            if (life <= 0)
            {
                BossDeath();
                Death();
            }

        }

        if (other.gameObject.tag == "SuperShot")
        {
            life -= playerController.playerDamage * 5;
            HitInstance();

            if (life <= 0)
            {
                BossDeath();
                Death();
            }

        }
    }
}
