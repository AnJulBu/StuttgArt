using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryScreen : MonoBehaviour
{
    [SerializeField]
    private Text text;


    
    
    public void SetContent(Destination destination)
    {
        text.text = destination.Story1;
        
    }
}