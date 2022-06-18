using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

[RequireComponent(typeof(Timer))]
public class VisualizedCountdown : MonoBehaviour
{
    public UnityEvent countdownStarted;
    public UnityEvent countdownAborted;
    public UnityEvent countdownEnded;

    [SerializeField, Tooltip("seconds that should be waited before triggering the countdownEnded event.")]
    private int waittime;

    private int secondsLeft;

    [SerializeField, Tooltip("Reference to the counter ui.")]
    private TMP_Text counter;

    [SerializeField, Tooltip("Reference to the timer component")]
    private Timer timer;

    [SerializeField, Tooltip("Reference to the trigger button which starts the countdown.")]
    private KeepPressedButton triggerButton;

    void Start()
    {
        triggerButton.OnBtnDown += StartTimer;
        triggerButton.OnBtnUp += AbortCountdown;
    }

    public void SecondPassed()
    {
        secondsLeft--;

        if (secondsLeft <= 0)
        {
            timer.Stop();
            countdownEnded?.Invoke();
        }
        else
        {
            counter.text = secondsLeft.ToString();
        }
    }

    public void StartTimer()
    {
        countdownStarted?.Invoke();
        secondsLeft = waittime;
        counter.text = secondsLeft.ToString();
        counter.gameObject.SetActive(true);
        timer.StartTimer();
    }

    public void AbortCountdown()
    {
        timer.Stop();
        counter.gameObject.SetActive(false);
        countdownAborted?.Invoke();
    }

}
