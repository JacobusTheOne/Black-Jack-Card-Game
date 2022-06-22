using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CardStack))]
public class CardStackView : MonoBehaviour
{
    CardStack deck;
    public Vector3 start;
    public float cardOffset;
    public GameObject cardPrefab;
    List<GameObject> tobeDestroyed;
    private void Start()
    {
        deck = GetComponent<CardStack>();
        tobeDestroyed = new List<GameObject>();
    }


    public void ShowCards()
    {
        if (tobeDestroyed.Count != 0)
        {
            foreach (GameObject i in tobeDestroyed)
            {
                Destroy(i);
            }
            tobeDestroyed.Clear();
        }
        int cardCount = 0;
        foreach (int i in deck.GetCards())
        {
            float co = cardOffset * cardCount;

            GameObject cardCopy = (GameObject)Instantiate(cardPrefab);
            tobeDestroyed.Add(cardCopy);
            Vector3 temp = start + new Vector3(co, 0f);
            CardModel refToCopy = cardCopy.GetComponent<CardModel>();
            refToCopy.cardIndex = i;
            refToCopy.ToggleFace(true);
            SpriteRenderer spriteRenderer = cardCopy.GetComponent<SpriteRenderer>();
            spriteRenderer.sortingOrder = cardCount;

            cardCopy.transform.position = temp;
            cardCount++;
        }
    }

}
