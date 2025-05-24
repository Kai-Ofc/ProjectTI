using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerController : MonoBehaviour
{
    public float time;
    private float timer;
    public GameObject[] enemyPrefab;

    public PlayerController player;
    public EnemyController enemy;

    public bool spawn;
    public int wave;
    public int instances;

    public void Start()
    {
        spawn = true;
        enemy = GetComponent<EnemyController>();

        EnemyController.kills = 0;
        instances = 0;
    }

    public void Update()
    {
        Spawner();
    }

    public void Spawner() 
    {

        if (spawn == true) 
        {
            timer += Time.deltaTime;

            if (instances < wave && timer >= time)
            {
                int randomIndex = Random.Range(0, enemyPrefab.Length);
                GameObject randomEnemyPrefab = enemyPrefab[randomIndex];

                GameObject newEnemy = Instantiate(randomEnemyPrefab, this.transform.position, Quaternion.identity);
                EnemyController enemyScript = newEnemy.GetComponent<EnemyController>();

                enemyScript.PlayerReference(player);

                timer = 0f;
                instances++;
            }

            if (EnemyController.kills >= wave)
            {
                Debug.Log("Victoryyy Kills: " + EnemyController.kills);
                SceneManager.LoadScene(2);
                return;
            }

            if (instances >= wave)
            {
                Debug.Log("Todos inimigos spawnados. Hora das kills");
                spawn = false;
            }

        }
        
    }
}
