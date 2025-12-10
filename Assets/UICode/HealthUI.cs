using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public Sprite FullHeartSprite;
    public Sprite EmptyHeartSprite;
    public Image[] HeartSprites;

    private int Hearts;

    public void Start()
    {
        Hearts = HeartSprites.Length;
        for (int i = 0; i < HeartSprites.Length; i++)
        {
            HeartSprites[i].sprite = FullHeartSprite;
        }
    }

    public void AddHeart()
    {
        if (Hearts < HeartSprites.Length)
        {
            HeartSprites[Hearts].sprite = FullHeartSprite;
            Hearts++;
        }
    }

    public void RemoveHeart()
    {
        if (Hearts > 0)
        {
            Hearts--;
            HeartSprites[Hearts].sprite = EmptyHeartSprite;
        }
    }
}