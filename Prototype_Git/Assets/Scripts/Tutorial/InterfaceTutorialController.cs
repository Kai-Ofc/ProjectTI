using UnityEngine;

public class InterfaceTutorialController : MonoBehaviour
{
    public PlayerTutorialController playerTutorial;
    public GameObject dialog;
    public GameObject cat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialog.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
