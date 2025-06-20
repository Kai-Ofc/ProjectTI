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
        //interfaceController = GetComponent<InterfaceController>();
        currentLife = maxLife;
        interfaceController.LifeBarr(currentLife, maxLife);
    }

    public void Hit(int damage, GameObject death) 
    {
       
        if (currentLife < 2)
        {
            Destroy(death, 1f);
            SceneManager.LoadScene(4);
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            currentLife -= damage;
            interfaceController.LifeBarr(currentLife, maxLife);
        }
    }

    public void Heal(int healAmount)
    {
        //currentLife = Mathf.Min(currentLife + healAmount, maxLife);
        currentLife += healAmount;
        interfaceController.LifeBarr(currentLife, maxLife);
    }
}
