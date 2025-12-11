using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    public Enemy Enemy;
    public Transform HealthBar;

    float maxHealth;
    float originalWidth;

    void Start()
    {
        maxHealth = Enemy.health;
        originalWidth = HealthBar.localScale.x;
    }

    void Update()
    {
        UpdateHealth();
    }

    void UpdateHealth()
    {
        float percent = Enemy.health / maxHealth;

        HealthBar.localScale = new Vector3(originalWidth * percent, HealthBar.localScale.y, HealthBar.localScale.z);
        HealthBar.localPosition = new Vector3(-(originalWidth - (originalWidth * percent)) / 2f, HealthBar.localPosition.y, HealthBar.localPosition.z);
    }
}