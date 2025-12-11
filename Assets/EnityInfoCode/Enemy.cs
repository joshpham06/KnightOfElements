using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public int health;
    public int damage; 
    public SpriteRenderer spriteRenderer;
    public PlayerInfo playerInfo;

    public void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        playerInfo = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInfo>(); 
    }
    private void Update()
    {

        if (health <= 0)
        {
            KillEnemy(); 
        }
        
    }
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            LoseHealth(10);
        }
    }
    
    public void LoseHealth(int amount)
    {
        this.health -= amount;
        if (this.health <= 0)
        {
            this.health = 0;
        }
        StartCoroutine(FlashRed());
    }

    private void KillEnemy()
    {
        if (this.CompareTag("Golem"))
        {
            playerInfo.AddScore(200);
            
        }
        if (this.CompareTag("Wolf"))
        {
            playerInfo.AddScore(100);
            
        }
        if (this.CompareTag("TentacleHead"))
        {
            playerInfo.AddScore(150);
            
        } 
        
        
        Destroy(gameObject);
    }
    
    IEnumerator FlashRed()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(.25f);
        spriteRenderer.color = Color.white;
    }
    
    
}
