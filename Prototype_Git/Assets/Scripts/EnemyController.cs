using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{

    public Transform follow;
    Vector3 distance;
    float radius;
    float angle;

    public float moveSpeed = 10.0f;
    public bool land = false;
    public bool rotate = false;

    public PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        land = false;
        rotate = false;
        //rb = GetComponent<Rigidbody>();

        distance = transform.position - follow.position;
        radius = distance.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement() 
    {
        transform.LookAt(follow.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);

        angle += moveSpeed * Time.deltaTime;
        distance = new Vector3(Mathf.Cos(angle) * radius, distance.y, Mathf.Sin(angle) * radius);

        if (land == true && playerController.camMovement != true)
        {

            if (rotate == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, distance, moveSpeed * Time.deltaTime);
            }

            transform.position = Vector3.MoveTowards(transform.position, follow.position, moveSpeed * Time.deltaTime);
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor") 
        {
            land = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trigger")
        {
            Debug.Log("Entrou no Trigger");
            rotate = true;
        }
    }
}
