using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    public Enemy Enemy;
    public Transform HealthBar;

    private int MaxHealth = 0;

    void Start()
    {
        MaxHealth = Enemy.health;
    }

    void Update()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        float percent = (float)Enemy.health / MaxHealth;

        HealthBar.localScale = new Vector3(percent, HealthBar.localScale.y, HealthBar.localScale.z);
        HealthBar.localPosition = new Vector3(-(1 - percent) / 2f, HealthBar.localPosition.y, HealthBar.localPosition.z);
    }
}