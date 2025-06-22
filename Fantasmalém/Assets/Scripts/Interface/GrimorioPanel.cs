using UnityEngine;
using UnityEngine.UI;

public class GrimorioPanel : MonoBehaviour
{
    public GameObject grimorioPanel;
    public Button exitButton;
    public void ExitButton()
    {
        grimorioPanel.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
