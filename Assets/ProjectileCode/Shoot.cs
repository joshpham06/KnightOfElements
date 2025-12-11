/*
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform bulletTransform;
    public float projectileTimeAlive = 5f;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    public void ShootBall(float force, GameObject prefab)
    {
        // spawn position
        Vector3 spawnPos = bulletTransform.position;

        // calculate mouse world position
        Vector3 mouse = Input.mousePosition;
        mouse.z = cam.WorldToScreenPoint(transform.position).z;
        Vector3 worldMouse = cam.ScreenToWorldPoint(mouse);

        // direction from spawn to mouse
        Vector3 dir = (worldMouse - spawnPos).normalized;
        dir.z = 0f;   // lock to 2D plane

        // instantiate ball
        GameObject ball = Instantiate(prefab, spawnPos, Quaternion.identity);

        // apply force
        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        rb.AddForce(dir * force, ForceMode2D.Impulse);

        Destroy(ball, projectileTimeAlive);
    }
}
*/ 



//Transformed old class with new one

using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    public Transform bulletTransform;
    public float projectileTimeAlive = 5f;
    public GamepadInput gamepadInput; // reference to your input handler

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    public void ShootBall(float force, GameObject prefab)
    {
        Vector3 spawnPos = bulletTransform.position;

        // ----------------------------
        // 1. Determine aim direction
        // ----------------------------
        Vector2 dir;

        bool usingGamepad = Gamepad.current != null && gamepadInput != null;
        usingGamepad = true; 

        if (usingGamepad)
        {
            // Aim with right stick / D-pad
            dir = gamepadInput.GetAimDirection();

            // If stick not moved yet, just fallback to mouse (avoid zero vector)
            if (dir.sqrMagnitude < 0.01f)
            {
                dir = GetMouseAimDirection(spawnPos);
            }
        }
        else
        {
            // Mouse aiming
            dir = GetMouseAimDirection(spawnPos);
        }

        // ----------------------------
        // 2. Spawn projectile
        // ----------------------------
        GameObject ball = Instantiate(prefab, spawnPos, Quaternion.identity);

        Rigidbody2D rb = ball.GetComponent<Rigidbody2D>();
        rb.AddForce(dir * force, ForceMode2D.Impulse);

        Destroy(ball, projectileTimeAlive);
    }

    // Helper method for mouse aiming
    private Vector2 GetMouseAimDirection(Vector3 spawnPos)
    {
        Vector3 mouse = Mouse.current.position.ReadValue();
        mouse.z = cam.WorldToScreenPoint(transform.position).z;

        Vector3 worldMouse = cam.ScreenToWorldPoint(mouse);

        Vector3 dir3D = (worldMouse - spawnPos).normalized;
        dir3D.z = 0f;
        return (Vector2)dir3D;
    }
}
