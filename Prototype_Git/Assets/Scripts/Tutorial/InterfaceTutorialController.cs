using UnityEngine;

public class InterfaceTutorialController : MonoBehaviour
{
    public PlayerTutorialController playerTutorial;
    public GameObject dialog;
    public GameObject cat;
    public GameObject movimentTutorial;
    public GameObject shotTutorial;
    public GameObject powerUpTutorial;
    public GameObject enemiesTutorial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialog.SetActive(true);
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
            cat.transform.Rotate(-10f, 0f, 0f, Space.Self);
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
