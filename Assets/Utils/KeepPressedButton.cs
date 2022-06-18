using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.Events;


public class KeepPressedButton : Button
{

    public delegate void BtnEvent();
    public BtnEvent OnBtnUp;
    public BtnEvent OnBtnDown;

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        OnBtnDown?.Invoke();
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        
        if (gameObject.activeSelf)
        {
            OnBtnUp?.Invoke();
        }
        
    }

}
