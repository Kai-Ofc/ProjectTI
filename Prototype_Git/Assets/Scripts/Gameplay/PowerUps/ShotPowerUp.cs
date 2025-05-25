using UnityEngine;

public class ShotPowerUp : MonoBehaviour
{
    public GameObject shotPrefab;
    Vector3 originalScale;
    public float sizeIncrease = 0.2f;

    //float timer;
    int duration;
    //bool count;

    public void Start()
    {
        originalScale = shotPrefab.transform.localScale;
        duration = 5;
        //count = false;
    }

    //public void Update()
    //{
    //    if (count == true) 
    //    {
    //        timer += Time.deltaTime;

    //        if (timer >= duration)
    //        {
    //            shotPrefab.transform.localScale = originalScale;
    //            Debug.Log("Power-Up acabou - tiros voltaram ao normal");
    //            count = false;
    //            timer = 0;
    //        }
    //    }

    //}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            shotPrefab.transform.localScale = originalScale + new Vector3(sizeIncrease, sizeIncrease, sizeIncrease);
            Invoke(nameof(ResetShotSize), duration);
            Destroy(gameObject);
        }
    }

    private void ResetShotSize()
    {
        shotPrefab.transform.localScale = originalScale;
        Debug.Log("Power-Up desativado");
    }
}
