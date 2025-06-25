using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GrimorioPanel : MonoBehaviour
{
    public GameObject grimorioPanel;
    public Button exitButton;
    public Button historyButton;
    public Button enemysButton;
    public Button powerupsButton;
    public Button creditosButton;
    public GameObject HistoryPanel;
    public GameObject EnemysPanel;
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

    public void EnemysButton()
    {
        ShowOnly(EnemysPanel);
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
        EnemysPanel.SetActive(selected == EnemysPanel);
        PowerUpsPanel.SetActive(selected == PowerUpsPanel);
        CreditosPanel.SetActive(selected == CreditosPanel);
    }

    public void ShowHistory() => ShowOnly(HistoryPanel);
}