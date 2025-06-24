using UnityEngine;

public class BossController : MonoBehaviour
{

    public Transform[] mirrorPositions;
    public float tpTime;
    public float startTime, endTime;
    public float tpTimer;

    public EnemyController enemyController;

    public Transform[] superShotPosition;
    public GunController gunController;
    public float timer;
    public float superTimer;

    void Start()
    {
        tpTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        tpTimer += Time.deltaTime;

        if (timer >= superTimer) 
        {
           gunController.BossSuperShot(superShotPosition);
            timer = 0;
        }

        if (tpTimer >= tpTime) 
        {
            Teleport();
            tpTimer = 0;
            tpTime = Random.Range(startTime, endTime);
        }
    }

    public void Teleport() 
    {
        int posIndex = Random.Range(0, mirrorPositions.Length);

        Transform nextPos = mirrorPositions[posIndex];

        this.transform.position = nextPos.position;
        transform.rotation = nextPos.rotation;
    }
}
