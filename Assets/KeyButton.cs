using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyButton : MonoBehaviour
{
    private string letter;
    private Button button;
    int currentColor = 0;
    enum BtnColors
    {
        white, green, red, grey
    }
    public Color Grey;
    public void Start()
    {
        letter = gameObject.name;
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(() => onClick());
        GameManager.i.buttonList.Add(this);
    }
    internal void disableButton()
    {
        currentColor = (int)BtnColors.grey;
        button.image.color = Color.grey;
    }
    public void onClick()
    {
        if ((BtnColors)currentColor != BtnColors.grey)
        {
            if (letter == "color")
            {
                GameManager.i.isInColorMode = !GameManager.i.isInColorMode;
                if ((BtnColors)currentColor == BtnColors.white)
                {
                    currentColor = (int)BtnColors.green;
                    button.image.color = Color.magenta;
                }
                else
                {
                    currentColor = (int)BtnColors.white;
                    button.image.color = Color.white;
                }
            }
            else if (GameManager.i.isInColorMode)
            {
                if (letter != "enter" && letter != "backspace")
                {
                    if ((BtnColors)currentColor == BtnColors.white)
                    {
                        currentColor = (int)BtnColors.green;
                        button.image.color = Color.green;
                    }
                    else if ((BtnColors)currentColor == BtnColors.green)
                    {
                        currentColor = (int)BtnColors.red;
                        button.image.color = Color.red;
                    }
                    else
                    {
                        currentColor = (int)BtnColors.white;
                        button.image.color = Color.white;
                    }
                }
            }
            else
            {
                GameManager.i.Type(letter);
            }
        }
    }
}
