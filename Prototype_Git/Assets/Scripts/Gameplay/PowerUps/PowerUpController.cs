using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    PlayerController playerController;
    float shieldTimer, projectilTimer, speedTimer;
    public int duration;

    //Escudo
    public bool protecion;

    //Tiro
    public GameObject shotPrefab;
    Vector3 originalScale;
    public float sizeIncrease = 0.2f;
    bool bigShot;
    int originalDamage;

    //SpeedBoost
    bool speedBoost;
    float originalMoveSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        originalScale = shotPrefab.transform.localScale;
        originalMoveSpeed = playerController.moveSpeed;
        originalDamage = playerController.damage;
    }

    // Update is called once per frame
    void Update()
    {
        shieldTimer += Time.deltaTime;
        projectilTimer +=Time.deltaTime;
        speedTimer += Time.deltaTime;
        StopShield();
        ResetShotSize();
        StopspeedBoost();
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

    public void SetSizeShot() 
    {
        shotPrefab.transform.localScale = originalScale + new Vector3(sizeIncrease, sizeIncrease, sizeIncrease);
        playerController.damage += 1;
        bigShot = true;
        projectilTimer = 0;
    }

    void ResetShotSize()
    {
        if(bigShot == true && projectilTimer >= duration) 
        { 
            bigShot = false;
            shotPrefab.transform.localScale = originalScale;
            playerController.damage = originalDamage;
            
        }
    }

    public void StartSpeedBoost() 
    {
        if (speedBoost != true) 
        {
            speedTimer = 0;
            speedBoost = true;
            playerController.moveSpeed *= 2.2f;
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
