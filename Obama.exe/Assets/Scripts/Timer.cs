using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    Text countdownUIElement;
    [SerializeField]
    float timeLeft = 120;


    private void Update()
    {
        //TODO: make the Countdown text to format: 00:00 (minutes:seconds)
        countdownUIElement.text = "Time remaining: " + timeLeft;
    }

    void StartTimer()
    {
        Debug.Log("Started Timer!");
        StartCoroutine(Countdown());
    }

    void TimerEnded()
    {
        Debug.Log("Stopped Timer!");
        StopCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        if (timeLeft == 0)
        {
            TimerEnded();
            yield return new WaitForSeconds(0.2f);
        }
        while (true)
        {
            TimeCount();
            yield return new WaitForSeconds(1);
        }
    }
    private void TimeCount()
    {
        timeLeft -= 1;
    }

}
