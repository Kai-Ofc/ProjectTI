using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{

    public GameObject follow;
    public float distance;

    public float moveSpeed = 10.0f;

    public bool land = false;

    PlayerController playerController;

    public GunController gun;
    float timer;
    public float time = 5f;

    public int life;
    public int damage;
    public static int kills;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        land = false;
        life = 3;

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
        //transform.Rotate(new Vector3(0, -90, 0), Space.Self);

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
        Debug.Log("Referencia Recebida");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor") 
        {
            land = true;
        }

        if (collision.gameObject.tag == "Shot")
        {
            life -= 1;

            if (life <= 1) 
            {
                kills++;
                Debug.Log("Inimigos mortos:" + kills);
                Destroy(this.gameObject);
            }
      
        }
    }
}
