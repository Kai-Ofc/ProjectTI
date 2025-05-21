using Unity.VisualScripting;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform shot;
    public Transform shotPosition;
    Transform shotObj;

    public void Shoot() 
    {
        shotObj = Instantiate(shot, shotPosition.position, shotPosition.rotation);
        Destroy(shotObj.gameObject, 2f);

        shotObj.GetComponent<ShotController>().SetDirection(shotPosition.forward);
    }
}
