using System;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class InterfaceController : MonoBehaviour
{
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
            newLife.transform.SetParent(lifePosition);
        }
    }
}
