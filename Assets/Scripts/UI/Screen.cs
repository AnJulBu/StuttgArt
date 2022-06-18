using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screen : MonoBehaviour
{
   public  void ShowScreen (Screen screen)
    {
        gameObject.SetActive(false);
        screen.gameObject.SetActive(true);
        /* foreach(Screen s in GameObject.FindObjectsOfType<Screen>(includeInactive:true))
        {
            
                s.gameObject.SetActive(s==screen);
            
        }*/
    }

}
