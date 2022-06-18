using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Timer : MonoBehaviour
{
    public UnityEvent OnTimeout;

    [SerializeField, Tooltip("The waittime in seconds.")]
    private float waittime = 0.0f;

    [SerializeField, Tooltip("If checked the timer starts after instantiation.")]
    private bool autostart = false;

    [SerializeField, Tooltip("If checked the timer stops after the first timeout, otherwise it proceeds.")]
    private bool oneshot = false;

    private float proceedingTime = -1.0f;

    void Start()
    {
        if (autostart)
        {
            SetProceedingTime();
        }
        else
        {
            Stop();
        }
    }

    void Update()
    {   
        if(Time.time >= proceedingTime)
        {
            StopTimer();
        }
    }

    private void SetProceedingTime()
    {
        proceedingTime = Time.time + waittime;
    }

    private void StopTimer()
    {
        OnTimeout?.Invoke();
        if (oneshot)
        {
            Stop();
        }
        else
        {
            SetProceedingTime();
        }
        
    }

    public void Stop()
    {
        this.enabled = false;
    }

    public void StartTimer()
    {
        this.enabled = true;
        SetProceedingTime();
    }

}
