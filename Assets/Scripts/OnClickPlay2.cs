using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnClickPlay2 : MonoBehaviour
{
    String player1Name = OnClickSelect.getPlayer1Name();
    String player2Name = OnClickSelect.getPlayer2Name();
    public Sprite CalvinSprite;
    public Sprite KiyanSprite;
    public Sprite JustinSprite;
    public Sprite NickSprite;
    public Sprite ColtonSprite;
    public Sprite StephenSprite;

    void Start()
    {
        if (player2Name.Equals("Calvin"))
        {
            this.GetComponent<SpriteRenderer>().sprite = CalvinSprite;
        }
        else if (player2Name.Equals("Kiyan"))
        {
            this.GetComponent<SpriteRenderer>().sprite = KiyanSprite;
        }
        else if (player2Name.Equals("Justin"))
        {
            this.GetComponent<SpriteRenderer>().sprite = JustinSprite;
        }
        else if (player2Name.Equals("Nick"))
        {
            this.GetComponent<SpriteRenderer>().sprite = NickSprite;
        }
        else if (player2Name.Equals("Colton"))
        {
            this.GetComponent<SpriteRenderer>().sprite = ColtonSprite;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = StephenSprite;
        }
    }
}
