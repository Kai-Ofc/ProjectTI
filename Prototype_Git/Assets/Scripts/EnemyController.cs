using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{

    public GameObject follow;
    public float distance;

    public float moveSpeed = 10.0f;
    public float angleSpeed = 1.0f;

    public bool land = false;

    public PlayerController playerController;

    public GunController gun;
    float timer;
    public float time = 5f;

    public int life;
    public int damage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        land = false;
        life = 3;
        follow = GameObject.FindGameObjectWithTag("Player");
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
        //transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        Vector3 enemyPosition = follow.transform.position + follow.transform.right * distance;

        transform.position = Vector3.MoveTowards(transform.position, enemyPosition, moveSpeed * Time.deltaTime);// Antes de entrar no trigger  
        

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor") 
        {
            land = true;
        }

        if (collision.gameObject.tag == "Shot")
        {
            if (life < 1) 
            {
                Destroy(this.gameObject);
                SceneManager.LoadScene(2);
                Cursor.lockState = CursorLockMode.None;
            }
            else { 
                life -= 1;
                Debug.Log("Vida Inimigo " + life);
            }
        }
    }
}
