using UnityEngine;
using UnityEngine.SceneManagement;

public class PowerUpSpawnerController : MonoBehaviour
{
    public float time;
    public float stopTime;
    private float timer;
    public GameObject[] powerUpPrefab;

    //public GameObject player;
    //public LifeController life;

    public bool spawn;
    //public int wave;
    //public int instances;

    public float spawX;
    public float spawZ;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawn = true;
    }

    // Update is called once per frame
    void Update()
    {
        Spawner();
    }

    public void Spawner()
    {

        if (spawn == true)
        {
            timer += Time.deltaTime;

            if (timer >= time)
            {
                int randomIndex = Random.Range(0, powerUpPrefab.Length);
                GameObject randomEnemyPrefab = powerUpPrefab[randomIndex];

                float randomX = Random.Range(-spawX, spawX);
                float randomZ = Random.Range(-spawZ, spawZ);
                Vector3 spawnPosition = transform.position + new Vector3(randomX, 0, randomZ);

                GameObject newPowerUp = Instantiate(randomEnemyPrefab, spawnPosition, Quaternion.identity);
                timer = 0f;
                Destroy(newPowerUp, 10f);
                

            }


        }

    }
}
