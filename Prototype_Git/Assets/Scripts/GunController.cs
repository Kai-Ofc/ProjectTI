using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform shot;
    public Transform shotPosition;

    public void Shoot() 
    {
        Transform shotObj = Instantiate(shot, shotPosition.position, shotPosition.rotation);
        Destroy(shotObj.gameObject, 2f);

        shotObj.GetComponent<ShotController>().SetDirection(shotPosition.forward);
    }
}
