using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform shot;
    public Transform superShot;
    public Transform[] shotPositions;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        AimAtMouse();
    }

    void AimAtMouse()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, transform.position.y);

        if (groundPlane.Raycast(ray, out float distance))
        {
            Vector3 targetPoint = ray.GetPoint(distance);

            foreach (Transform shotPos in shotPositions)
            {
                Vector3 direction = targetPoint - shotPos.position;
                direction.y = 0f;
                if (direction.sqrMagnitude > 0.001f)
                    shotPos.rotation = Quaternion.LookRotation(direction);
            }
        }
    }

    public void Shoot()
    {
        foreach (Transform shotPos in shotPositions)
        {
            Transform shotObj = Instantiate(shot, shotPos.position, shotPos.rotation);
            Destroy(shotObj.gameObject, 2f);

            shotObj.GetComponent<ShotController>().SetDirection(shotPos.forward);
        }
    }

    public void SuperShot()
    {
        foreach (Transform shotPos in shotPositions)
        {
            Transform superShotObj = Instantiate(superShot, shotPos.position, shotPos.rotation);
            Destroy(superShotObj.gameObject, 5f);

            superShotObj.GetComponent<ShotController>().SetDirection(shotPos.forward);
        }
    }
}
