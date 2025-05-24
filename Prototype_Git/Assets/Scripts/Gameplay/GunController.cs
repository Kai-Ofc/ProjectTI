using Unity.VisualScripting;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform shot;
    public Transform superShot;
    public Transform[] shotPositions;
    Transform shotObj;
    Transform superShotObj;

    public void Shoot() 
    {
        foreach (Transform shotPos in shotPositions) 
        {
            shotObj = Instantiate(shot, shotPos.position, shotPos.rotation);
            Destroy(shotObj.gameObject, 2f);

            shotObj.GetComponent<ShotController>().SetDirection(shotPos.forward);
        }
            
    }

    public void SuperShot()
    {
        foreach (Transform shotPos in shotPositions)
        {
            superShotObj = Instantiate(superShot, shotPos.position, shotPos.rotation);
            Destroy(superShotObj.gameObject, 5f);

            superShotObj.GetComponent<ShotController>().SetDirection(shotPos.forward);
        }

    }
}
