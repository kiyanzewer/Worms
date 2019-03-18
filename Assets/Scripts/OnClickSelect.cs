using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickSelect : MonoBehaviour
{
    public Text current;
    public static int currentPlayer = 1;
    int clickCounter = 0;
    public Text player1;
    public Text player2;
    public Button select;
    public Button menu;
    public static bool ready = false;

    public void OnClick()
    {
        if (player1.text.Length > 10)
        {
            menu.interactable = false;
            clickCounter++;
            current.text = "Currently: Player 2";
            currentPlayer = 2;
            if (player2.text.Length > 10 && clickCounter >= 2)
            {
                select.interactable = false;
                ready = true;
            }
        }
    }

    public static int currentPlayerVal()
    {
        return currentPlayer;
    }

    public static bool getReady()
    {
        return ready;
    }
}
