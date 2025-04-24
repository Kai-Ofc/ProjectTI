using UnityEngine;

public class CameraControlleer : MonoBehaviour
{

    public GameObject follow; //Ponto que a camera vai seguir
    public GameObject lookAt; //Ponto que a camera vai olhar

    public float smoothness; //Fluides do movimento da camera

    public PlayerController playerController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false; //Oculta o cursor do mouse
        Cursor.lockState = CursorLockMode.Locked; //Trava o cursor do centro
    }

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
        else if (playerController.camMovement == true)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
