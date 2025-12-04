using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            health -= 10;
        }
        
        if (health <= 0)
            Destroy(gameObject);
    }
}
