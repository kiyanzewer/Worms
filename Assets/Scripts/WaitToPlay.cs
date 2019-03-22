using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitToPlay : MonoBehaviour
{
    public Button play;

    void Update()
    {
        if (OnClickSelect.getClickCounter() < 2)
        {
            play.interactable = false;
        }
    }
}
