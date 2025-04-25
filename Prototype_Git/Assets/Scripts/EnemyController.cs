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

    public float minWaitTime = 1.0f;
    public float maxWaitTime = 3.0f;
    public float minMovementTime = 2.0f;
    public float maxMovementTime = 15.0f;

    private float currentTimer = 0f;
    private bool isMoving = true;
    private float currentMovementDuration = 0f;

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
            currentTimer += Time.deltaTime;

            if (rotate == true)
            {

                if (rotate == true)
                {
                    if (isMoving == true)
                    {
                        currentMovementDuration += Time.deltaTime;

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

                        
                        if (currentMovementDuration >= Random.Range(minMovementTime, maxMovementTime)) // Verifica se deve parar de se mover
                        {
                            isMoving = false;
                            currentTimer = 0f;
                            currentMovementDuration = 0f;
                        }
                    }
                    else 
                    {
                        // Verifica se deve voltar a se mover
                        if (currentTimer >= Random.Range(minWaitTime, maxWaitTime))
                        {
                            isMoving = true;
                            currentTimer = 0f;
                           
                            angleSpeed = Mathf.Sign(angleSpeed) * Random.Range(0.5f, 2f); // Mantém o sentido mas varia velocidade escolhe nova direção aleatória

                            if (Random.value > 0.7f) // // Chance de inverter direção
                            {
                                angleSpeed *= -1;
                            }
                        }
                        
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

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Trigger")
        {
            Debug.Log("Saiu do Trigger");
            rotate = false;


        }
    }
}
