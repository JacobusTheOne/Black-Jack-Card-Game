using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDealer : MonoBehaviour
{
    public CardStack dealerStack;
    public CardStack playerStack;
    public CardStackView dealerView;
    public CardStackView playerView;
    private void OnGUI()
    {
        if(GUI.Button(new Rect(10,10,256,28),"Hit me"))
        {
            playerStack.Push(dealerStack.Pop());
            print("This is working");
            dealerView.ShowCards();
            playerView.ShowCards();
        }
    }



}
