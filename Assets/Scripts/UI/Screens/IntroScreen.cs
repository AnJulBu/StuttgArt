using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroScreen : MonoBehaviour
{
    [SerializeField]
    private Text text;
    public void SetContent(Tour tour)
    {   
        text.text = tour.Description;
    }
}
