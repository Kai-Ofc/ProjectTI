using UnityEngine;

public class PlayerTutorialController : MonoBehaviour
{
    public bool scenary;
    public bool movementInterface;
    public bool enemies;
    public bool powerUp;
    public GameObject powerUps;
    float timer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movementInterface = true;
        powerUps.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 5f) 
        {
            movementInterface = false;
            timer = 0;
        }

        if (timer >= 5f && movementInterface == false) 
        { 
            enemies = true;
            scenary = true;
            timer = 0;
        }

        if(timer >= 5f && enemies == true) 
        { 
            powerUp = true;
            powerUps.SetActive(true);
        }
    }
}
