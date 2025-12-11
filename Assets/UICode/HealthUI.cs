using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Image HealthBar;
    public ScreenStateUI ScreenStateUI;
     
    public void UpdateHealth(int health)
    {
        HealthBar.fillAmount = health / 100f;
        
        if (health <= 0)
            ScreenStateUI.ShowLoseScreen();
    }
}