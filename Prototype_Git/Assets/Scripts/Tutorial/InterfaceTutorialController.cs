using UnityEngine;

public class InterfaceTutorialController : MonoBehaviour
{
    public PlayerTutorialController playerTutorial;
    public GameObject movimentTutorial;
    public GameObject shotTutorial;
    public GameObject powerUpTutorial;
    public GameObject enemiesTutorial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        movimentTutorial.SetActive(true);
        shotTutorial.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTutorial.movementInterface == false) 
        {
            movimentTutorial.SetActive(false);
            shotTutorial.SetActive(true);
        }

        if (playerTutorial.enemies == true && playerTutorial.scenary == true) 
        {
            enemiesTutorial.SetActive(true);
        }

        if (playerTutorial.powerUp == true) 
        { 
            powerUpTutorial.SetActive(true);
        }
    }
}
