using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform bulletTransform;
    public float radius = 1f;

    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        // Get mouse world position at object's depth
        Vector3 mouse = Input.mousePosition;
        mouse.z = cam.WorldToScreenPoint(transform.position).z;
        Vector3 worldMouse = cam.ScreenToWorldPoint(mouse);

        // Direction from pivot to mouse
        Vector3 dir = (worldMouse - transform.position).normalized;

        // Lock to 2D plane (XY)
        dir.z = 0f;

        // Position bullet around pivot
        bulletTransform.position = transform.position + dir * radius;

        // Optionally rotate bullet to face mouse
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        bulletTransform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
}