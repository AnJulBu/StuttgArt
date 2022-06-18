using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Timer))]
public class SliderAnimation : MonoBehaviour
{

    [SerializeField, Tooltip("Reference to the slider to animate")]
    private Slider slider;

    [SerializeField, Tooltip("Reference to the tick-timer of the slider")]
    private Timer timer;

    public void OnEnable()
    {
        slider.value = slider.minValue;
        timer.StartTimer();
    }

    public void Tick()
    {
        slider.value += 1;
        if(slider.value >= slider.maxValue)
        {
            timer.Stop();
        }
    }

}
