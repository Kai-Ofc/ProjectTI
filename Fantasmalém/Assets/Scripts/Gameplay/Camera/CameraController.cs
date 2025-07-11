using UnityEngine;

public class CameraControlleer : MonoBehaviour
{

    public GameObject follow; //Ponto que a camera vai seguir
    public GameObject lookAt; //Ponto que a camera vai olhar

    public float smoothness; //Fluides do movimento da camera

    public PlayerController playerController;

    // Update is called once per frame
    void Update()
    {
        CamMovement();
    }

    void CamMovement() 
    {
        if (playerController.camMovement != true)
        {
            transform.position = Vector3.Lerp(transform.position, follow.transform.position, smoothness * Time.deltaTime);
            transform.LookAt(lookAt.transform);
        }
    }
}
