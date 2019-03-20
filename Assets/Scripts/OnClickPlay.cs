using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickPlay : MonoBehaviour
{
    String player1Name = OnClickSelect.getPlayer1Name();
    String player2Name = OnClickSelect.getPlayer2Name();
    public Sprite CalvinSprite;

    void Start()
    {
        if(player1Name.Equals("Calvin"))
        {
            this.GetComponent<SpriteRenderer>().sprite = CalvinSprite;
        }
    }
}
