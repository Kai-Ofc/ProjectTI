using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PortalManagerController : MonoBehaviour
{
    public EnemyController enemy;
    public SpawnerController spawner;
    public GameObject portal;
    public GameObject enemyPreFab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy = enemyPreFab.GetComponent<EnemyController>();
        spawner = GetComponent<SpawnerController>();
        portal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Inimigos mortos:" + enemy.kills);
        //Debug.Log("Wave: " + spawner.wave);

        if (spawner.instances >= spawner.wave) 
        {
            portal.SetActive(true);
        }
    }
}
