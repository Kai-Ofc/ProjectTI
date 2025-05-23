using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnerController : MonoBehaviour
{
    public float time;
    private float timer;
    public GameObject enemyPrefab;

    public PlayerController player;
    public EnemyController enemy;

    public bool spawn;
    public int wave;
    int instances;

    public void Start()
    {
        time = 10f;
        spawn = true;
        enemy = GetComponent<EnemyController>();
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

            if (instances >= wave) 
            {
                Debug.Log(EnemyController.kills);
                spawn = false;
            }

            if (EnemyController.kills >= wave)
            {
                Debug.Log("Entrou aqui");
                SceneManager.LoadScene(2);
                
            }
            else
            {
                if (timer >= time)
                {

                    //var position = new Vector3(Random.Range(-19.56f, 19.56f), 0, 0);
                    GameObject newEnemy = Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);

                    EnemyController enemyScript = newEnemy.GetComponent<EnemyController>();

                    enemyScript.PlayerReference(player);

                    timer = 0f;
                    instances++;
                }
            }

        }
        
    }
}
