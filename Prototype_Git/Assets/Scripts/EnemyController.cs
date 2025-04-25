using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public Transform follow;
    Vector3 distance;
    float radius;
    float angle;

    public float moveSpeed = 10.0f;
    public float angleSpeed = 1.0f;
    public bool land = false;
    public bool rotate = false;

    public PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        land = false;
        rotate = false;
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

        if (land == true && playerController.camMovement != true)
        {
            if (rotate == true)
            {

                if (rotate == true)
                {
                    Vector3 nextPos = follow.position + new Vector3(Mathf.Cos(angle + angleSpeed * Time.deltaTime) * radius, distance.y, Mathf.Sin(angle + angleSpeed * Time.deltaTime) * radius); // Verifica se há parede na direção do movimento

                    if (!Physics.Linecast(transform.position, nextPos)) //!Physics.Linecast: Caso não tenha nenhuma colisão entre as (posição inicial, posição final) o movimento segue normalmente
                    {
                        angle += angleSpeed * Time.deltaTime;
                        distance = new Vector3(Mathf.Cos(angle) * radius, distance.y, Mathf.Sin(angle) * radius);
                        transform.position = follow.position + distance;
                    }
                    else
                    {
                        angleSpeed *= -1; // Inverte direção
                    }

                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, follow.position, moveSpeed * Time.deltaTime);// Antes de entrar no trigger
            }
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

            distance = transform.position - follow.position; // Calcula a distância
            radius = distance.magnitude; // Calcula o raio
 
            angle = Mathf.Atan2(distance.z, distance.x);// Calcula o ângulo inicial baseado na posição atual do inimigo em relação ao player
            //Atan2 = retorna o angulo em radiano do float y (distance.z) / float x (distance.x)

        }
    }
}
