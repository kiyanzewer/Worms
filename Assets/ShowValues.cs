using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowValues : MonoBehaviour
{
    public Text powerText;
    public Slider powerSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextUpdate(powerSlider.value);
    }

    void TextUpdate(float value)
    {
        powerText.text = Mathf.RoundToInt(value) + "";
    }
}
