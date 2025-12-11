using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public Transform bulletTransform;
    public float projectileTimeAlive = 5f;
    public GamepadInput gamepadInput; 

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    public void ShootBall(float force, GameObject prefab)
    {
        Vector3 spawnPos = bulletTransform.position;

        // ---------- Choose aim direction ----------
        Vector2 dir = Vector2.zero;

        bool hasGamepad =
            Gamepad.current != null &&
            gamepadInput != null;

        if (hasGamepad)
        {
            // Try gamepad aim first
            dir = gamepadInput.GetAimDirection();

            // If the stick/D-pad isn't being moved, fall back to mouse
            if (dir.sqrMagnitude < 0.01f)
            {
                dir = GetMouseAimDirection(spawnPos);
            }
        }
        else
        {
            // No gamepad? Pure mouse aiming.
            dir = GetMouseAimDirection(spawnPos);
        }

        // Safety: if somehow still zero, default to the right
        if (dir.sqrMagnitude < 0.0001f)
            dir = Vector2.right;

        // ---------- Spawn + fire ----------
        GameObject ball = Instantiate(prefab, spawnPos, Quaternion.identity);

        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        rb.AddForce(dir * force, ForceMode2D.Impulse);

        Destroy(ball, projectileTimeAlive);
    }

    // Helper method for mouse aiming
    private Vector2 GetMouseAimDirection(Vector3 spawnPos)
    {
        if (Mouse.current == null)
            return Vector2.right; // fallback if no mouse (e.g. controller-only device)

        Vector3 mouse = Mouse.current.position.ReadValue();

        // Distance from camera so ScreenToWorldPoint works correctly
        mouse.z = cam.WorldToScreenPoint(transform.position).z;

        Vector3 worldMouse = cam.ScreenToWorldPoint(mouse);

        Vector3 dir3D = (worldMouse - spawnPos).normalized;
        dir3D.z = 0f; // stay in 2D plane

        return (Vector2)dir3D;
    }
}
