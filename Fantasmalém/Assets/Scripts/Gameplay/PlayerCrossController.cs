using UnityEngine;

public class PlayerCrossController : MonoBehaviour
{
    GunController gun;
    private Camera mainCamera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gun = GetComponent<GunController>();
        mainCamera = Camera.main;
    }

    // Update is called once per frame
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

            foreach (Transform shotPos in gun.shotPositions)
            {
                Vector3 direction = targetPoint - shotPos.position;
                direction.y = 0f;
                if (direction.sqrMagnitude > 0.001f)
                    shotPos.rotation = Quaternion.LookRotation(direction);
            }
        }
    }
}
