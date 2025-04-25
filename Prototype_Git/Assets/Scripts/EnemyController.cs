using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Transform follow;
    public float moveSpeed = 10.0f;
    public bool land = false;
    //private Rigidbody rb;

    public PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (land == true && playerController.camMovement != true) 
        {
            transform.LookAt(follow.position);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);
            transform.position = Vector3.MoveTowards(transform.position, follow.position, moveSpeed * Time.deltaTime);
            //rb.AddForce((follow.position - transform.position).normalized * moveSpeed);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor") 
        {
            land = true;
        }
    }
}
