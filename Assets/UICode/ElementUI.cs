using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementUI : MonoBehaviour
{
    public CanvasGroup[] ElementBorders;
    public Image[] ElementColors;
    public Image PlayerColor;
 
    private int CurrentElementIndex = 0;

    void Start()
    {
        ResetElements();
        UpdateElementIcon(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
            SelectElement(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) 
            SelectElement(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) 
            SelectElement(2);
        if (Input.GetKeyDown(KeyCode.Alpha4)) 
            SelectElement(3);
        if (Input.GetKeyDown(KeyCode.Alpha5)) 
            SelectElement(4);
    }
    
    public int FetchElement()
    {
        return CurrentElementIndex;
    }

    private void SelectElement(int index)
    {
        SwitchElement(index);
        UpdateElementIcon(index);
        UpdatePlayerColor(index);
    }

    private void SwitchElement(int index)
    {
        // Has this been replaced elsewhere?
    }

    private void UpdateElementIcon(int index)
    {
        ElementBorders[CurrentElementIndex].alpha = 0;
        ElementBorders[index].alpha = 1;
        CurrentElementIndex = index;
    }
    
    private void ResetElements()
    {
        for (int i = 0; i < ElementBorders.Length; i++)
        {
            ElementBorders[i].alpha = 0;
        }
    }

    private void UpdatePlayerColor(int index)
    {
        Color elementColor = ElementColors[index].color;
        PlayerColor.color = elementColor;
    }
}