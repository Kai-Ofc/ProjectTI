using UnityEngine;

public class InterfaceTutorialController : MonoBehaviour
{
    PlayerTutorialController playerTutorial;
    public GameObject movimentTutorial;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerTutorial = GetComponent<PlayerTutorialController>();
        movimentTutorial.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTutorial.movementInterface == true) 
        {
            movimentTutorial.SetActive(false);
        }
    }
}
