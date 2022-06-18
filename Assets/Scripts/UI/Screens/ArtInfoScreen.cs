using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtInfoScreen : MonoBehaviour
{
    [SerializeField]
    private Text text;

    public Sprite sprite;
    public SpriteRenderer spriteRenderer;
    public void SetContent(Destination destination)
    {
          text.text = destination.ArtInfo1;
           sprite  = destination.Image;
        spriteRenderer.sprite = sprite;
    }

}
