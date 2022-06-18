using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hugo : MonoBehaviour
{
       
    [HideInInspector]
    public Screen screen;
   
   
    public void show()
    {
        gameObject.SetActive(true);
    }
    public void hide()
    {   
       gameObject.SetActive(false);
            
    }
   
}
