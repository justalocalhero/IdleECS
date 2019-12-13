using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int index { get; set; }

    public void OnMouseDown()
    {
        CardTray.instance.dragged = this;
    }

    public void OnMouseUp()
    {
        CardTray.instance.dragged = null;
    }
}
