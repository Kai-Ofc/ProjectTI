using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour
{
    public int maxLife;
    public int currentLife;

    public InterfaceController interfaceController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentLife = maxLife;
        Debug.Log(currentLife);
        interfaceController.LifeBar(currentLife, maxLife);
    }

    public void Hit(int damage, GameObject death) 
    {
       
        if (currentLife < 2)
        {
            Destroy(death, 1f);
            SceneManager.LoadScene(2);
        }
        else
        {
            currentLife -= damage;
            Debug.Log("Vida Player " + currentLife);
            interfaceController.LifeBar(currentLife, maxLife);
        }
    }

    public void Heal(int healAmount)
    {
        currentLife = Mathf.Min(currentLife + healAmount, maxLife);
        interfaceController.LifeBar(currentLife, maxLife);
    }
}
