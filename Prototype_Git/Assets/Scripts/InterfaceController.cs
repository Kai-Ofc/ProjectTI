using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    public GameObject lifeImg;
    public GameObject lifePosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LifeBar(int life) 
    {
        for (int i = 0; i < life; i++) 
        {
            var calcX = lifePosition.transform.position.x + (i * 110); // Calculo do espaçamento entre as vidas

            GameObject lifes = Instantiate(lifeImg, new Vector3(calcX, lifePosition.transform.position.y, 0), Quaternion.identity, this.transform);
          
        }
    }
}
