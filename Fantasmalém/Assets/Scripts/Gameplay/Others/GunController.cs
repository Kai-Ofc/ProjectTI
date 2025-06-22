using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform shot;
    public Transform superShot;
    public Transform[] shotPositions;

    public void Shoot()
    {
        foreach (Transform shotPos in shotPositions)
        {
            Transform shotObj = Instantiate(shot, shotPos.position, Quaternion.LookRotation(shotPos.forward));
            Destroy(shotObj.gameObject, 2f);

            shotObj.GetComponent<ShotController>().SetDirection(shotPos.forward);
        }
    }

    public void SuperShot()
    {
        foreach (Transform shotPos in shotPositions)
        {
            Transform superShotObj = Instantiate(superShot, shotPos.position, Quaternion.LookRotation(shotPos.forward));
            Destroy(superShotObj.gameObject, 5f);

            superShotObj.GetComponent<ShotController>().SetDirection(shotPos.forward);
        }
    }
}
