using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool destroyOnWall = true;
    public bool destroyOnEnemy = true;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") && destroyOnWall == true)
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Wolf") && destroyOnEnemy  == true)
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Golem") && destroyOnEnemy  == true)
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("TentacleHead") && destroyOnEnemy  == true)
        {
            Destroy(gameObject);
        }
    }
}
