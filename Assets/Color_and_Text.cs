using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Color_and_Text : MonoBehaviour
{
    Image color;
    TMP_Text text;

    public void Awake()
    {
        color = GetComponentInChildren<Image>();
        text = GetComponentInChildren<TMP_Text>();
    }

    public void SetColor(Color newColor)
    {
        color.color = newColor;
    }

    public void SetText(string newText)
    {
        text.text = newText;
    }    

}
