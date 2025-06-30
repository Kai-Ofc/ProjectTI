using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeController : MonoBehaviour
{
    public int maxLife;
    public int currentLife;

    public InterfaceController interfaceController;

    private bool vidaInfinita = false;

    void Start()
    {
        currentLife = maxLife;
        interfaceController.LifeBarr(currentLife, maxLife);
    }

    public void Hit(int damage, GameObject death)
    {
        if (vidaInfinita)
            return;

        if (currentLife <= 1)
        {
            Destroy(death, 1f);
            SceneManager.LoadScene(5);
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
        currentLife += healAmount;
        interfaceController.LifeBarr(currentLife, maxLife);
    }
    
        public void SetVidaInfinita(bool estado)
    {
        vidaInfinita = estado;
    }
}
