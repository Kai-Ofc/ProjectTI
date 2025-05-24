using Unity.VisualScripting;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform shot;
    //public Transform shotPosition;
    public Transform[] shotPositions;
    Transform shotObj;

    public void Shoot() 
    {
        foreach (Transform shotPos in shotPositions) 
        {
            shotObj = Instantiate(shot, shotPos.position, shotPos.rotation);
            Destroy(shotObj.gameObject, 2f);

            shotObj.GetComponent<ShotController>().SetDirection(shotPos.forward);
        }
            
    }
}
