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
    public int orda;
    public int clones;

    public void Start()
    {
        time = 10f;
        clones = 0;
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
            if (clones >= orda)
            {
                spawn = false;
                if (enemy.life <= 0)
                {
                    SceneManager.LoadScene(2);
                }
            }
            else 
            {
                if (timer >= time)
                {

                    timer += Time.deltaTime;

                    //var position = new Vector3(Random.Range(-19.56f, 19.56f), 0, 0);
                    GameObject newEnemy = Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);

                    EnemyController enemyScript = newEnemy.GetComponent<EnemyController>();

                    enemyScript.PlayerReference(player);

                    timer = 0f;
                    clones++;
                }
            }
        }
        
    }
}
