using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementHandler : MonoBehaviour
{
    public Image[] ElementBorders;
    public Sprite RegularBorder;
    public Sprite HighlightedBorder;

    private int CurrentElementIndex = 0;

    void Start()
    {
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

    private void SelectElement(int index)
    {
        SwitchElement(index);
        UpdateElementIcon(index);
    }
    
    private void SwitchElement(int index)
    {
        
    }

    private void UpdateElementIcon(int index)
    {
        ElementBorders[CurrentElementIndex].sprite = RegularBorder;
        ElementBorders[index].sprite = HighlightedBorder;
        CurrentElementIndex = index;
    }
}