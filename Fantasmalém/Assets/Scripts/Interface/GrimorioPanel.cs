using UnityEngine;
using UnityEngine.UI;

public class GrimorioPanel : MonoBehaviour
{
    public GameObject grimorioPanel;
    public Button exitButton;
    public Button historyButton;
    public Button howToPlayButton;
    public Button powerupsButton;
    public Button creditosButton;
    public GameObject HistoryPanel;
    public GameObject HowToPlayPanel;
    public GameObject PowerUpsPanel;
    public GameObject CreditosPanel;


    public void ExitButton()
    {
        grimorioPanel.SetActive(false);
    }

    public void HistoryButton()
    {
        ShowOnly(HistoryPanel);
    }

    public void HowToPlayButton()
    {
        ShowOnly(HowToPlayPanel);
    }

    public void PowerUpsButton()
    {
        ShowOnly(PowerUpsPanel);
    }

    public void CreditosButton()
    {
        ShowOnly(CreditosPanel);
    }

    private void ShowOnly(GameObject selected)
    {
        HistoryPanel.SetActive(selected == HistoryPanel);
        HowToPlayPanel.SetActive(selected == HowToPlayPanel);
        PowerUpsPanel.SetActive(selected == PowerUpsPanel);
        CreditosPanel.SetActive(selected == CreditosPanel);
    }

    private void OnEnable()
    {
        ShowOnly(HistoryPanel); 
    }
}