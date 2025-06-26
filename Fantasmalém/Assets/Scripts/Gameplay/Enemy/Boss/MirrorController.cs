using UnityEngine;

public class MirrorController : MonoBehaviour
{
    public GunController gun;
    public float shotTimer, shotTime, start, end;

    public void Start()
    {
        shotTime = Random.Range(start, end);
    }

    public void Update()
    {
        shotTimer += Time.deltaTime;

        if (shotTimer >= shotTime) 
        {
            gun.Shoot();
            shotTimer = 0;
            shotTime = Random.Range(start, end);
        }
    }
}
