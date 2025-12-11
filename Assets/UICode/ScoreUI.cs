using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text ScoreText;
    
    public void UpdateScore(int score)
    {
        ScoreText.text = score.ToString();
    }
}
