using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed, maxSpeed, drag;
    private bool foward, backward, left, right;
    public int shotTime, superShotTime;
    float superTimer;

    public float sensitivity = 1000f; // Sensibilidade do mouse
    float mouseX;

    public bool camMovement;

    public GunController gun; // Arma

    public LifeController lifeController; // Vida
    public int damage;// Dano Tomado

    public EnemyController enemy; // Inimigo

    public GameObject shieldPositionsVector;
    public Transform[] shieldsPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        camMovement = false;
        Cursor.lockState = CursorLockMode.Locked;

        shieldPositionsVector.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        LimitVelocity();
        HandleDrag();

        superTimer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            gun.Shoot();
        }

        if (Input.GetMouseButtonDown(1) && superTimer >= superShotTime)
        {
            gun.SuperShot();
            superTimer = 0;
        }
    }

    private void FixedUpdate()
    {
        if (foward)
        {
            rb.AddForce(moveSpeed * Vector3.forward);
            foward = false;
        }

        if (backward)
        {
            rb.AddForce(moveSpeed * Vector3.back);
            backward = false;
        }

        if (right)
        {
            rb.AddForce(moveSpeed * Vector3.right);
            right = false;
        }

        if (left)
        {
            rb.AddForce(moveSpeed * Vector3.left);
            left = false;
        }
    }

    void Movement()
    {

        if (Input.GetKey(KeyCode.W))
        {
            foward = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            backward = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
             left = true;            
        }

        if (Input.GetKey(KeyCode.D))
        {
            right = true; 
        }

        mouseX -= Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        transform.localEulerAngles = new Vector3(0, mouseX, 0); // Mudando o angulo local do player através do mouse

    }

    void LimitVelocity()    
    {
        Vector3 horizontalVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z); // Acessar a velocidade em x e z do personagem

        if (horizontalVelocity.magnitude > maxSpeed)  // Logica para limitar a velocidade e o personagem não acelerar quanto mais andar
        {
            Vector3 limitation = horizontalVelocity.normalized * maxSpeed; // Normalizando a velocidade e multiplicar pela velocidade maxima
            rb.linearVelocity = new Vector3(limitation.x, rb.linearVelocity.y, limitation.z); // Integrar a limitação a velocidade
        }
    }

    void HandleDrag() //Função para cocertar o deslizamento
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z) / (1 + drag / 100) + new Vector3(0, rb.linearVelocity.y, 0); // Lógica para concertar o "deslizamento" do personagem
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyShot")
        {
            lifeController.Hit(enemy.damage, this.gameObject);
        }
    }
}
