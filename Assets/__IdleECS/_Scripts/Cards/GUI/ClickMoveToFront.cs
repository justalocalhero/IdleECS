using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMoveToFront : MonoBehaviour
{
    public Vector3 zoom;

    void OnMouseDown()
    {   
        if(CardTray.instance.dragged != null) return;

        Vector3 pos = transform.localPosition;

        transform.localPosition = (transform.localPosition + zoom);
    }
}
