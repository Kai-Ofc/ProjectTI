using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    PlayerController playerController;
    float shieldTimer, projectilTimer;
    public int duration;

    //Escudo
    public bool protecion;

    //Tiro
    public GameObject shotPrefab;
    Vector3 originalScale;
    public float sizeIncrease = 0.2f;
    bool bigShot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerController = GetComponent<PlayerController>();
        originalScale = shotPrefab.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        shieldTimer += Time.deltaTime;
        projectilTimer+=Time.deltaTime;
        StopShield();
        ResetShotSize();
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
            Debug.Log("Shield desativado");
            playerController.shields.SetActive(false);
            protecion = false;
            
        }
    }

    public void SetSizeShot() 
    {
        shotPrefab.transform.localScale = originalScale + new Vector3(sizeIncrease, sizeIncrease, sizeIncrease);
       bigShot = true;
        projectilTimer = 0;
    }

    void ResetShotSize()
    {
        if(bigShot == true && projectilTimer >= duration) 
        { 
            bigShot = false;
            shotPrefab.transform.localScale = originalScale;
            Debug.Log("Shot desativado");
            
        }
    }
}
