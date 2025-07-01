using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public float time;
    private float timer;
    public GameObject[] enemyPrefab;

    public PlayerController player;
    public EnemyController enemyScript;
    public int kills;

    public bool spawn;
    public int wave;
    public int instances;

    public float spawX;

    public void Start()
    {
        spawn = true;
        enemyScript = GetComponent<EnemyController>();
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

                float randomX = Random.Range(-spawX, spawX);
                Vector3 spawnPosition = transform.position + new Vector3(randomX, 0, 0);

                GameObject newEnemy = Instantiate(randomEnemyPrefab, spawnPosition, Quaternion.identity);
                enemyScript = newEnemy.GetComponent<EnemyController>();

                enemyScript.PlayerReference(player);

                timer = 0f;
                instances++;

            }

            if (instances >= wave)
            {
                spawn = false;
            }

        }
        
    }

    public void Kills() 
    {
        kills++;
    }
}
