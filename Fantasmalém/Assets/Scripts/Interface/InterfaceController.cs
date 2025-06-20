using System;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    //public Image lifeBar;

    //public void LifeBar( int currentLife, int maxLife) 
    //{
    //    lifeBar.fillAmount = (float)currentLife / maxLife;
    //}

    public Sprite blankLamp;
    public Sprite fullLamp;
    public GameObject lifePrefab;
    public RectTransform lifePosition;
    public float spacing;

    public void LifeBarr(int currentLife, int maxLife)
    {
        Vector2 startPosition = lifePosition.anchoredPosition;

        for (int i = 0; i < maxLife; i++)
        {
            GameObject newLife = Instantiate(lifePrefab, transform);

            if (currentLife <= i)
            {
                newLife.GetComponent<Image>().sprite = blankLamp;
            }
            else
            {
                newLife.GetComponent<Image>().sprite = fullLamp;
            }

            RectTransform rt = newLife.GetComponent<RectTransform>();
            rt.anchoredPosition = startPosition + new Vector2(i * spacing, 0);

            //var calcX = transform.position.x + (i * -60);
            //Instantiate(life, new Vector3(calcX, life.transform.position.y, 0), Quaternion.identity, this.transform);

            //newLife.transform.localPosition = new Vector3(i * -60f, 0, 0);
        }
    }
}
