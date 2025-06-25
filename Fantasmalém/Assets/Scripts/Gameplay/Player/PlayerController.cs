using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed, maxSpeed, drag;
    private bool foward, backward, left, right;

    public float minX = -10f;
    public float minZ = -10f;

    public float maxX = 10f;
    public float maxZ = 10f;

    public int superShotTime;
    float superTimer;

    public float sensitivity;
    float mouseX;

    public bool camMovement;

    public GunController gun; // Arma

    public LifeController lifeController; // Vida
    public int damage;// Dano Tomado

    public EnemyController enemy; // Inimigo

    public GameObject shields;
    public PowerUpController powerUp;

    public MenuController menuController;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        camMovement = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        superTimer = 10f;
        shields.SetActive(false);

        menuController = FindAnyObjectByType<MenuController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        LimitVelocity();
        HandleDrag();

        RotateTowardsMouse();

        superTimer += Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {
            if (Time.timeScale == 1)
            {
                gun.Shoot();
            }
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

    public void LateUpdate()
    {
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);
        clampedPosition.z = Mathf.Clamp(clampedPosition.z, minZ, maxZ);
        transform.position = clampedPosition;
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

        mouseX += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        transform.localEulerAngles = new Vector3(0, mouseX, 0);

    }

    void LimitVelocity()
    {
        Vector3 horizontalVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);

        if (horizontalVelocity.magnitude > maxSpeed)
        {
            Vector3 limitation = horizontalVelocity.normalized * maxSpeed;
            rb.linearVelocity = new Vector3(limitation.x, rb.linearVelocity.y, limitation.z);
        }
    }

    void HandleDrag()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z) / (1 + drag / 100) + new Vector3(0, rb.linearVelocity.y, 0);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyShot" && powerUp.protecion != true)
        {
            lifeController.Hit(enemy.damage, this.gameObject);
        }

        if (this.gameObject.tag == "Player" && other.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(2);
        }
    }
    
    void RotateTowardsMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector3 target = hit.point;
            target.y = transform.position.y;

            Vector3 direction = (target - transform.position).normalized;

            if (direction != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 10f * Time.deltaTime);
            }
        }
    }
}
