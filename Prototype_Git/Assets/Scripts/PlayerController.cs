using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    Rigidbody rb;
    public float moveSpeed = 20.0f;
    Vector3 movement;

    public GameObject cameraTransform; // Referencia da camera
    public float rotationSpeed = 10f;

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
    }

    void Movement() 
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float zAxis = Input.GetAxisRaw("Vertical");
        movement = new Vector3(xAxis, 0, zAxis) * moveSpeed * Time.deltaTime;
        //rb.MovePosition(transform.position + movement);

        movement = new Vector3(xAxis, 0, zAxis).normalized; // Vetor baseado no input e diagonais consistentes

        if (movement.magnitude >= 0.1f) // Se houver movimento
        {

            Vector3 moveDirection = cameraTransform.transform.forward * movement.z + cameraTransform.transform.right * movement.x; // Calcular direção do movimento

            moveDirection.y = 0;

            rb.MovePosition(transform.position + (moveDirection.normalized * moveSpeed * Time.deltaTime));  // Mover o jogador

            Quaternion targetRotation = Quaternion.LookRotation(-cameraTransform.transform.forward); // Rotacionar o jogador para olhar na direção oposta a camera

            targetRotation.x = 0; // Manter a rotação no eixo Y
            targetRotation.z = 0;

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); // Rotação suave
        }
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
