using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BossController : MonoBehaviour
{

    //public Transform[] mirrorPositions;
    public float timer;
    //public float tpTime;
    //public float startTime;
    //public float endTime;

    public EnemyController enemyController;

    public Transform[] superShotPosition;
    public GunController gunController;
    public float superTimer;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= superTimer) 
        {
           gunController.BossSuperShot(superShotPosition);
            timer = 0;
        }
    }
}
