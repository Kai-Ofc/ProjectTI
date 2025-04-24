using UnityEngine;

public class CameraPointController : MonoBehaviour
{
    public GameObject follow; // O que o ponto vai seguir
    public float sensitivity; // A sensibilidade do movimento

    Vector3 offset; // A distancia do objeto

    float radius; // Raio da rotação
    float mouseX; // Posição horizontal do mouse

    public PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - follow.transform.position; // Calculo da posição
        radius = offset.magnitude; // Calculo para o raio
    }

    // Update is called once per frame
    void Update()
    {
        CamPointMovement();
    }

    void CamPointMovement() 
    {
        if (playerController.camMovement != true) 
        {
            transform.position = follow.transform.position + offset; //Mudar a posição do ponto, conforme a movimentação do objeto que segue

            mouseX -= Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime; //Posição horizontal do mouse conforme a sensibilidade e o time.deltatime

            offset = new Vector3(Mathf.Cos(mouseX) * radius, offset.y, Mathf.Sin(mouseX) * radius); //Fazer o offset seguir o raio ao ponto de fazer uma circunferencia completa

            follow.transform.localEulerAngles = new Vector3(0, mouseX, 0);
        }
    }
}
