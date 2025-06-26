using UnityEngine;

public class MirrorController : MonoBehaviour
{
    public GunController gun;
    public bool trigger;

    public void Start()
    {
        Debug.Log("Triger " + trigger);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag == "Trigger" && other.gameObject.tag == "Boss") 
        {
            Debug.Log("Trigger " + trigger);
            gun.Shoot();
        }    
    }
}
