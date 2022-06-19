using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtInfoScreen : MonoBehaviour
{
    [SerializeField]
    private Text text;

    public Image image;
   
    public void SetContent(Destination destination)
    {
          text.text = destination.ArtInfo1;
           image.sprite  = destination.Image;
       
    }

}
