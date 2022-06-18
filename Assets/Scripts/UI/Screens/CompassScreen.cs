using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CompassScreen : MonoBehaviour
{
    [SerializeField]
    private Text text;
    [SerializeField]
    private Text text1;
    public void SetContent(Destination destination)
    {
        text.text = destination.OneLiner;
        text1.text = destination.TourId;
    }

}
