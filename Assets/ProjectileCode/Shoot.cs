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