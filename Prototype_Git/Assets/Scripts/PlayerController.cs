using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed, maxSpeed, drag;

    private bool foward, backward, left, right;

    public bool camMovement;

    public InterfaceController interfaceController;
    public int life;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    
        camMovement = false;
        life = 3;

        interfaceController.LifeBar(life);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        LimitVelocity();
        HandleDrag();
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
            Debug.Log("W");
            foward = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            Debug.Log("S");
            backward = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A");
             left = true;            
        }

        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("D");
            right = true; 
        }

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
        if (collision.gameObject.tag == "Enemy")
        {
     
            if (life <= 1) 
            {
                camMovement = true;

                Destroy(this.gameObject);
                SceneManager.LoadScene(2);
            }
            else
            {
                Debug.Log("Deu Ruim");
                life -= 1;
                Debug.Log(life);
            }

        }
    }
}
