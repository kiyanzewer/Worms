using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getCurrentPlayer : MonoBehaviour
{
    public Text current;

    void Start()
    {
        if (OnClickSelect.currentPlayerVal() == 2)
        {
            current.text = "Currently: Player 2";
        }
        Debug.Log(current.text);
    }
}
