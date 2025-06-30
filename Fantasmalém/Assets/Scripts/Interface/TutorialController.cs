using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public GameObject tutorial;
    float timer;

    void Start()
    {
        tutorial.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 8f) 
        {
            tutorial.SetActive(false);
        }
    }
}
