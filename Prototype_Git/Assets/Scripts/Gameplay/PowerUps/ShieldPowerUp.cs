using UnityEngine;

public class ShieldPowerUp : MonoBehaviour
{
    public Transform shield;
    public GameObject player;
    public PlayerController playerController;
    Transform shieldObj;
    bool protecion;
    float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        protecion = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && protecion != true)
        {
            playerController.shieldPositionsVector.SetActive(true);
            Shield();
            Destroy(this.gameObject);
            protecion = true;

            if (timer >= 5f) 
            {
                protecion = false;
                timer = 0;
            }
        }
    }

    public void Shield() 
    {
        foreach (Transform shieldPos in playerController.shieldsPos)
        {
            shieldObj = Instantiate(shield, shieldPos.position, shieldPos.rotation);
            Destroy(shieldObj.gameObject, 5f);

            shieldObj.position = Vector3.MoveTowards(shieldObj.position, shieldPos.position, playerController.maxSpeed * Time.deltaTime);
        }
    }
}
