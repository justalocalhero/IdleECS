using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardTray : MonoBehaviour
{
    public Card dragged;
    public List<Card> cards;

    public static CardTray instance;
    public int slots;

    void Awake()
    {
        if(instance != null) GameObject.Destroy(this);
        else instance = this;
    }

    void Update()
    {
        if(dragged != null)
        {
            Vector3 mousePoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        }
    }

    void Start()
    {
        for(int i = 0; i < cards.Count; i++)
        {
            cards[i].index = i;
        }
	
    }

    public void Swap(int a, int b)
    {
        if(a == b) return;
        if(a < 0 || b < 0 || a >= cards.Count || b >= cards.Count) return;
        Card temp = cards[a];
        cards[a] = cards[b];
        cards[b] = temp;
    }

    public void AddCard(Card card)
    {
        cards.Add(card);
        card.index = cards.Count;
    }

    public int CalculateSlot(float x)
    {
        Debug.Log(x);
        return Mathf.Clamp(Mathf.FloorToInt(x / 2), 0, slots);
    }
}
