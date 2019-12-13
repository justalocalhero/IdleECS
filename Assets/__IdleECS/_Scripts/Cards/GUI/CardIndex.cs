using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardIndex : MonoBehaviour
{
    private int index;

    public void SwapIndex(CardIndex cardIndex)
    {
        int temp = index;
        index = cardIndex.index;
        cardIndex.index = temp;
    }

    
}
