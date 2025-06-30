using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;

public class BossLifeBar : MonoBehaviour
{
    public Slider slider;

    public int VidaMaxima
    {
        set
        {
            this.slider.maxValue = value;
        }
    }

    public int Vida
    {
        set
        {
            this.slider.value = value;
        }
    }
}
