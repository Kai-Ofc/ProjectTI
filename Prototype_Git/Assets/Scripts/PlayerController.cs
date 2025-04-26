using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed, maxSpeed, drag;
    private bool foward, backward, left, right;

    private float sensitivity = 1000f; // Sensibilidade do mouse
    float mouseX;

    public bool camMovement;

    public GameObject trigger;

    public GunController gun;

    public LifeController lifeController;
    public int damage;

    public EnemyController enemy;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    
        camMovement = false;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        LimitVelocity();
        HandleDrag();

        if (Input.GetMouseButtonDown(0))
        {
            gun.Shoot();
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

        trigger.transform.position = new Vector3(this.transform.position.x, trigger.transform.position.y, this.transform.position.z);

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
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z) / (1 + drag / 100) + new Vector3(0, rb.linearVelocity.y, 0); // Lógica para concertar o "deslizamento" do presonagem
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shot")
        {
            lifeController.Hit(enemy.damage, this.gameObject); 
        }
    }
}
