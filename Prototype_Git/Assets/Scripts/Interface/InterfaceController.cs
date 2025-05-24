using System;
using UnityEngine;
using UnityEngine.UI;

public class InterfaceController : MonoBehaviour
{
    public Image lifeBar;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LifeBar( int currentLife, int maxLife) 
    {
        lifeBar.fillAmount = (float)currentLife / maxLife;
    }
}
