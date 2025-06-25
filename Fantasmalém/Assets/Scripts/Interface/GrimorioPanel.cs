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

    public Animator[] powerUpsAnimators;
    public string powerUpsAnimationName = "PowerUpsAnim";

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
        StartCoroutine(ActivateAndPlayAnimations());
    }

    private IEnumerator ActivateAndPlayAnimations()
    {
        if (!PowerUpsPanel.activeSelf)
            PowerUpsPanel.SetActive(true);

        ActivateChildren(PowerUpsPanel);

        yield return null;

        PlayPowerUpsAnimations();
    }

    private void ActivateChildren(GameObject parent)
    {
        foreach (Transform child in parent.transform)
        {
            if (!child.gameObject.activeSelf)
                child.gameObject.SetActive(true);
        }
    }

    private void PlayPowerUpsAnimations()
    {
        foreach (Animator anim in powerUpsAnimators)
        {
            if (anim != null && anim.gameObject.activeInHierarchy)
            {
                Debug.Log("Reproduzindo animação: " + anim.gameObject.name);
                anim.Play(0, 0, 0f);
                anim.Update(0f);
            }
            else
            {
                Debug.LogWarning("Animator nulo ou GameObject inativo.");
            }
        }
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