using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardStack : MonoBehaviour
{
    List<int> cards;
    public bool isGameDeck;
    public List<GameObject> listCardInstances;
    private void Start()
    {
        listCardInstances = new List<GameObject>();
    }
    public void AddCardsInstances(GameObject it)
    {
        listCardInstances.Add(it);
    }
    public GameObject PopCardInstances()
    {
        if (listCardInstances != null)
        {
            GameObject temp = listCardInstances[0];
            listCardInstances.RemoveAt(0);
            return temp;
        }
        else
            return null;
        
    }

    public IEnumerable<int> GetCards()
    {
        foreach (int i in cards)
        {
            yield return i;
        }
    }
    public int Pop()
    {
        int temp = cards[0];
        cards.RemoveAt(0);
        return temp;
    }

    public void Push(int card)
    {
        cards.Add(card);
    }


    public void CreateDeck()
    {
        for(int i = 0; i<52; i++)
        {
            cards.Add(i);
        }

        int n = cards.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            int temp = cards[k];
            cards[k] = cards[n];
            cards[n] = temp;
        }
    }
    void Awake()
    {
        cards = new List<int>();
        if (isGameDeck)
        {
            CreateDeck();
        }
    }

   
}
