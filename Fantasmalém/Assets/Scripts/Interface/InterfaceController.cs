using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    public Sprite blankLamp;
    public Sprite fullLamp;
    public Sprite fullLaser;
    public Sprite blankLaser;

    public Image laser;
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

    public void LaserIndicator(float timer, float time) 
    {
        if ( timer >= time)
        {
            laser.GetComponent<Image>().sprite = fullLaser;
        }
        else 
        {
            laser.GetComponent<Image>().sprite = blankLaser;
        }
    }
}
