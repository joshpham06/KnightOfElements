using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public int health;
    
    private void Update()
    {

        if (health <= 0)
        {
            KillEnemy(); 
        }
        
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile") )
        {
            LoseHealth(10);
        }
    }
    
    public void LoseHealth(int health)
    {
        this.health -= health;
        if (this.health <= 0)
        {
            this.health = 0;
        }
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }
    
}
