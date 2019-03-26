using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnStartHideImages : MonoBehaviour
{
    public Image sprite;

    void Start()
    {
        sprite.enabled = false;
    }

    
}
