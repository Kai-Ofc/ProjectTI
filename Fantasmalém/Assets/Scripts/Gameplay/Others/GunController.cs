using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform shot;
    public Transform superShot;
    public Transform[] shotPositions;
    public Transform[] mimicAssets;

    public void Shoot()
    {
        foreach (Transform shotPos in shotPositions)
        {
            Transform shotObj = Instantiate(shot, shotPos.position, Quaternion.LookRotation(shotPos.forward));
            if (this.gameObject.tag == "Trigger")
            {
                Destroy(shotObj.gameObject, 5f);
            }
            else
            {
                Destroy(shotObj.gameObject, 2f);
            }

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

    public void BossSuperShot()
    {
        bool[] usedPositions = new bool[shotPositions.Length];

        for (int i = 0; i < Mathf.Min(4, shotPositions.Length); i++)
        {
            int randomIndex;

            do
            {
                randomIndex = Random.Range(0, shotPositions.Length);
            }
            while (usedPositions[randomIndex]);

            usedPositions[randomIndex] = true;

            Transform shotPos = shotPositions[randomIndex];
            Transform superShotObj = Instantiate(shot, shotPos.position, Quaternion.LookRotation(shotPos.forward));
            Destroy(superShotObj.gameObject, 2f);

            superShotObj.GetComponent<ShotController>().SetDirection(shotPos.forward);
        }
    }

    public void GhostShot()
    {
        bool[] usedPositions = new bool[shotPositions.Length];

        for (int i = 0; i < Mathf.Min(2, shotPositions.Length); i++)
        {
            int randomIndex;

            do
            {
                randomIndex = Random.Range(0, shotPositions.Length);
            }
            while (usedPositions[randomIndex]);

            usedPositions[randomIndex] = true;

            Transform shotPos = shotPositions[randomIndex];
            Transform superShotObj = Instantiate(shot, shotPos.position, Quaternion.LookRotation(shotPos.forward));
            Destroy(superShotObj.gameObject, 2f);

            superShotObj.GetComponent<ShotController>().SetDirection(shotPos.forward);
        }
    }

    public void MimicShoot()
    {
        foreach (Transform shotPos in shotPositions)
        {
            int shotIndex = Random.Range(0, mimicAssets.Length);
            Transform mimicShot = mimicAssets[shotIndex];

            Transform shotObj = Instantiate(mimicShot, shotPos.position, Quaternion.LookRotation(shotPos.forward));

            SetupParabolicShot(shotObj, shotPos.forward);

            Destroy(shotObj.gameObject, 2f);
        }
    }

    public void SetupParabolicShot(Transform shotObj, Vector3 direction)
    {
        float shotSpeed = 11f;
        float shotAngle = 45f;

        float angleRad = shotAngle * Mathf.Deg2Rad;

        Vector3 horizontalDir = new Vector3(direction.x, 0f, direction.z).normalized;

        Rigidbody rb = shotObj.GetComponent<Rigidbody>();

        Vector3 force = horizontalDir * shotSpeed * Mathf.Cos(angleRad);
        force.y = shotSpeed * Mathf.Sin(angleRad);

        rb.AddForce(force, ForceMode.VelocityChange);
    }

}
