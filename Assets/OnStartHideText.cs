using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnStartHideText : MonoBehaviour
{
    public Text desc;
    void Start()
    {
        desc.enabled = false;
    }

    
}
