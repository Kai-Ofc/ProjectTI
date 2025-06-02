using UnityEngine;

public class InterfaceTutorialController : MonoBehaviour
{
    public PlayerTutorialController playerTutorial;
    public GameObject movimentTutorial;
    public GameObject shotTutorial;
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
    }
}
