using UnityEngine;

public class EnemyTutorialController : MonoBehaviour
{
    public PlayerTutorialController playerTutorial;
    public GameObject enemies;
    public GameObject objects;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemies.SetActive(false);
        objects.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
