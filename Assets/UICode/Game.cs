using UnityEngine;

public class Game : MonoBehaviour
{
    public ScreenStateUI ScreenStateUI;
    
    public void Awake()
    {
        ScreenStateUI.ShowStartScreen();
    }
    
    public void OnPlayButtonClick()
    {
        ScreenStateUI.HideStartScreen();
    }
    
    public void OnPlayAgainButtonClick()
    {
        ScreenStateUI.HideLoseScreen();
        ScreenStateUI.ShowStartScreen();
        ScreenStateUI.HideWinScreen();
    }
}
