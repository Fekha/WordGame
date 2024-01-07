using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyButton : MonoBehaviour
{
    public string letter;

    public void onClick()
    {
        GameManager.i.Type(letter);
    }
}
