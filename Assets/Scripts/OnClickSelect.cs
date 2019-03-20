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
    public static String player1Name;
    public static String player2Name;

    public void OnClick()
    {
        if (player1.text.Length > 10)
        {
            player1Name = player1.text.Substring(11);
            menu.interactable = false;
            clickCounter++;
            current.text = "Currently: Player 2";
            currentPlayer = 2;
            if (player2.text.Length > 10 && clickCounter >= 2)
            {
                player2Name = player2.text.Substring(11);
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

    public static String getPlayer1Name()
    {
        return player1Name;
    }

    public static String getPlayer2Name()
    {
        return player2Name;
    }
}
