using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Card))]
public class SlideToIndex : MonoBehaviour
{
    private Card card;
    public float zPerIndex;

    void Start()
    {
        card = GetComponent<Card>();
    }

    void Slide(int index)
    {
        Vector3 localPosition = transform.localPosition;
        transform.localPosition = new Vector3
        {
            x = 0,
            y = 0,
            z = zPerIndex * index
        };
    }

    void OnMouseUp()
    {
        Slide(card.index);
    }
}
