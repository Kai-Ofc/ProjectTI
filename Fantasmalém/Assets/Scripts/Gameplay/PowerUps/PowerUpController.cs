using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    PlayerController playerController;
    GunController gunController;

    float shieldTimer, projectilTimer, speedTimer, rechardeTimer;
    public int duration;

    //Escudo
    public bool protecion;

    //Tiro
    public Transform shotPrefab;
    public Transform bigShotPrefab;
    public float sizeIncrease = 0.2f;
    public bool bigShot;

    //Recarga
    int originalRecharge;
    public bool recharge;

    //SpeedBoost
    bool speedBoost;
    float originalMoveSpeed;

    void Start()
    {
        playerController = GetComponent<PlayerController>();
        gunController = GetComponent<GunController>();

        originalMoveSpeed = playerController.moveSpeed;
        originalRecharge = playerController.superShotTime;

        shieldTimer = 0;
        projectilTimer = 0;
        speedTimer = 0;
        rechardeTimer = 0;
    }

    void Update()
    {
        shieldTimer += Time.deltaTime;
        projectilTimer +=Time.deltaTime;
        speedTimer += Time.deltaTime;
        rechardeTimer += Time.deltaTime;
        StopShield();
        ResetShotSize();
        StopspeedBoost();
        StopRechard();
    }

    public void StartShield() 
    {
        shieldTimer = 0;
        protecion = true;      
        playerController.shields.SetActive(true); 
    }

    void StopShield() 
    {
        if (protecion == true && shieldTimer >= duration)
        {
            playerController.shields.SetActive(false);
            protecion = false;
            
        }
    }

    public void StartRechard()
    {
        rechardeTimer = 0;
        recharge = true;
        playerController.superShotTime = 1;
    }

    void StopRechard()
    {
        if (recharge == true && rechardeTimer >= duration)
        {
            playerController.shields.SetActive(false);
            recharge = false;
            playerController.superShotTime = originalRecharge;
        }
    }

    public void SetSizeShot() 
    {
        gunController.shot = bigShotPrefab;
        bigShot = true;
        projectilTimer = 0;
    }

    void ResetShotSize()
    {
        if(bigShot == true && projectilTimer >= duration) 
        { 
            bigShot = false;
            gunController.shot = shotPrefab;
        }
    }

    public void StartSpeedBoost() 
    {
        if (speedBoost != true) 
        {
            speedTimer = 0;
            speedBoost = true;
            playerController.moveSpeed *= 2f;
        }

    }

    public void StopspeedBoost()
    {
        if (speedBoost == true && speedTimer >= duration)
        {
            speedBoost = false;
            playerController.moveSpeed = originalMoveSpeed;

        }
    }
}
