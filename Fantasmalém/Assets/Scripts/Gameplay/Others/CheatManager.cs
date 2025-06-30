using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Importante para manipular UI

public class CheatManager : MonoBehaviour
{
    public string nomeCenaBoss = "BossScene";
    public string nomeCenaVitoria = "VictoryScene";

    private LifeController lifeController;

    public GameObject iconeVidaInfinita;

    private bool vidaInfinitaAtiva = false;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            lifeController = player.GetComponent<LifeController>();
        }

        if (iconeVidaInfinita != null)
        {
            iconeVidaInfinita.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            TrocarDeFase();
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            vidaInfinitaAtiva = !vidaInfinitaAtiva;

            if (lifeController != null)
            {
                lifeController.SetVidaInfinita(vidaInfinitaAtiva);
            }

            if (iconeVidaInfinita != null)
            {
                iconeVidaInfinita.SetActive(vidaInfinitaAtiva);
            }
        }
    }

    void TrocarDeFase()
    {
        string cenaAtual = SceneManager.GetActiveScene().name;

        if (cenaAtual == nomeCenaBoss)
        {
            SceneManager.LoadScene(nomeCenaVitoria);
        }
        else
        {
            int proximaCena = SceneManager.GetActiveScene().buildIndex + 1;
            if (proximaCena < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(proximaCena);
            }
        }
    }
}
