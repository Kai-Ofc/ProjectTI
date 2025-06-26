using UnityEngine;

public class BossController : MonoBehaviour
{

    public Transform[] mirrorPositions;

    public float tpTime, tpTimer;
    public float startTime, endTime;

    public EnemyController enemyController;

    void Start()
    {
        tpTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        tpTimer += Time.deltaTime;
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
