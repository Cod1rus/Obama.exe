using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    GameObject[] countdownUIElement;

    float timeLeft = 30;

    

    private void Update()
    {
        countdownUIElement = GameObject.FindGameObjectsWithTag("Countdown UI");
        //TODO: make the Countdown text to format: 00:00 (minutes:seconds)
        foreach (GameObject _text in countdownUIElement)
        {
            Text temp = _text.GetComponent<Text>();
            temp.text = "Time Remaining: " + timeLeft;
        }
    }

    public void StartTimer(float _time)
    {
        timeLeft = _time;
        Debug.Log("Started Timer!" + _time + " seconds");
        StartCoroutine(Countdown());
    }

    void TimerEnded()
    {
        Debug.Log("Stopped Timer!");
        StopCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {

        while (true)
        {
            if (timeLeft <= 0)
            {
                TimerEnded();
                yield return new WaitForSeconds(0.2f);
                break;
            }
            TimeCount();
            yield return new WaitForSeconds(1);
        }
    }
    private void TimeCount()
    {
        timeLeft -= 1;
    }

}
