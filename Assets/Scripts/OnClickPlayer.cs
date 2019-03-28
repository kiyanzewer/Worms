using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickPlayer : MonoBehaviour
{
    public Text player1;
    public Text player2;
    public Button select;
    public Image sprite;
    public Image power;

    public void OnClick(string name)
    {
        if (OnClickSelect.getReady() == false)
        {
            if (OnClickSelect.currentPlayerVal() == 1)
            {
                player1.text = "Player 1: " + name;
            }
            else
            {
                player2.text = "Player 2: " + name;
            }
        }
        sprite.enabled = true;
        power.enabled = true;
    }
}
