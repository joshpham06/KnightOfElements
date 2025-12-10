using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image HealthBar;
    
    public void UpdateHealth(int health)
    {
        HealthBar.fillAmount = health / 100f;
    }
}