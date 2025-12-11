using UnityEngine;
using UnityEngine.UI;

public class ScreenStateUI : MonoBehaviour
{
    public CanvasGroup StartScreenCanvasGroup;
    public CanvasGroup WinScreenCanvasGroup;
    public CanvasGroup LoseScreenCanvasGroup;
    
    public void ShowStartScreen()
    {
        CanvasGroupDisplayer.Hide(WinScreenCanvasGroup);
        CanvasGroupDisplayer.Hide(LoseScreenCanvasGroup);
        CanvasGroupDisplayer.Show(StartScreenCanvasGroup);
    }
    
    public void HideStartScreen()
    {
        CanvasGroupDisplayer.Hide(StartScreenCanvasGroup);
    }
    
    public void ShowWinScreen()
    {
        CanvasGroupDisplayer.Show(WinScreenCanvasGroup);
    }
    
    public void HideWinScreen()
    {
        CanvasGroupDisplayer.Hide(WinScreenCanvasGroup);
    }
    
    public void ShowLoseScreen()
    {
        CanvasGroupDisplayer.Show(LoseScreenCanvasGroup);
    }
    
    public void HideLoseScreen()
    {
        CanvasGroupDisplayer.Hide(LoseScreenCanvasGroup);
    }
}
