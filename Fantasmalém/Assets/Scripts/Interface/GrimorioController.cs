using UnityEngine;

public class GrimorioController : MonoBehaviour
{
    public GameObject grimorioPanel;

    private void Start()
    {
        grimorioPanel.SetActive(false);    
    }

    public void OpenButton() 
    {
        grimorioPanel.SetActive(true);
    }

    public void ExitButton()
    {
        grimorioPanel.SetActive(false);
    }
}
