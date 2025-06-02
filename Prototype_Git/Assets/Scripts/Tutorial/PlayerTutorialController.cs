using UnityEngine;

public class PlayerTutorialController : MonoBehaviour
{
    public bool spawn;
    public bool movementInterface;
    float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementInterface = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 5f) 
        {
            spawn = true;
            movementInterface = false;
        }
    }
}
