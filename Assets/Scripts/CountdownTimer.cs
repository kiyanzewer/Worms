using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    [SerializeField] private Text uiText;
    [SerializeField] private float mainTimer;
    private float timer;
    private bool canCount = true;
    private bool doOnce = false;
    private bool timeLeft;
    // Start is called before the first frame update
    void Start()
    {
        timer = mainTimer;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(uiText);
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            uiText.text = timer.ToString("f");
        }
        else if (timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            uiText.text = "0.00";
            timer = 0.0f;
        }

    }

    public void Reset()
    {
        StartCoroutine(restartTimer());
    }
    IEnumerator restartTimer()
    {
        yield return new WaitForSecondsRealtime(1);
        timer = mainTimer;
        canCount = true;
        doOnce = false;
        timeLeft = true;
    }
    public bool ReturnTime()
    {
        return uiText.text == "0.00";
    }
    public void setText()
    {
        uiText.text = "5.00";
    }
}
