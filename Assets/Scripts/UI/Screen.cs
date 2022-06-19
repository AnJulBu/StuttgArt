using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
   public  void ShowScreen (Screen screen)
    {
        gameObject.SetActive(false);
        screen.gameObject.SetActive(true);
       
    }
    public void ShowScreen1(Screen screen)
    {
        gameObject.SetActive(false);
        screen.gameObject.SetActive(true);
        

        
    }

}
