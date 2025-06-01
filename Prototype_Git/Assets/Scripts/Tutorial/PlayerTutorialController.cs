using UnityEngine;

public class PlayerTutorialController : MonoBehaviour
{
    public bool spawn;
    public bool movementInterface;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementInterface = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) 
        {
            spawn = true;
            movementInterface = false;
        }
    }
}
