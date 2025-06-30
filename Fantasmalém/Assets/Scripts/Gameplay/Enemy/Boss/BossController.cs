using UnityEngine;

public class BossController : MonoBehaviour
{

    public Transform[] mirrorPositions;

    public float tpTime, tpTimer;
    public float startTime, endTime;

    public EnemyController enemyController;

    public AudioSource sfxSource;
    public AudioClip tpSound;

    public Animator anim;

    void Start()
    {
        tpTime = startTime;
        sfxSource = GetComponent<AudioSource>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        tpTimer += Time.deltaTime;
        if (tpTimer >= tpTime) 
        {
            sfxSource.PlayOneShot(tpSound);
            Teleport();
            tpTimer = 0;
            tpTime = Random.Range(startTime, endTime);
            anim.SetBool("Teleport", false);
        }
    }

    public void Teleport() 
    {
        anim.SetBool("Teleport", true);
        int posIndex = Random.Range(0, mirrorPositions.Length);

        Transform nextPos = mirrorPositions[posIndex];

        this.transform.position = nextPos.position;
        transform.rotation = nextPos.rotation;
    }
}
