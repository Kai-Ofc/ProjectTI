using UnityEngine;

public class CameraPointController : MonoBehaviour
{
    public GameObject follow; // O que o ponto vai seguir
    public float smoothness; // A sensibilidade do movimento

    Vector3 offset; // A distancia do objeto

    public PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - follow.transform.position; // Calculo da posição
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
            transform.position = Vector3.Lerp((follow.transform.position + offset), follow.transform.position, smoothness * Time.deltaTime);
        }
    }
}
