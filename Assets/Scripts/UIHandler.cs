using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    // Initialize GameObjects to represent the visabillity of the screens 

    public GameObject screen1;
    public GameObject screen2;
    public GameObject screen3;
    public GameObject screen4;
    public GameObject screen5;
    public GameObject screen6;





    public void SwitchSecondScreen()
    {
        
        screen1.SetActive(false);
        screen2.SetActive(true);
        
    }
    public void SwitchThirdScreen()
    {

        screen2.SetActive(false);
        screen3.SetActive(true);

    }
    public void SwitchScene1()
    {
        PlayerPrefs.SetString("xmlRoot", "eins");
        SceneManager.LoadScene("TourScene");
    }
    public void SwitchScene2()
    {
        PlayerPrefs.SetString("xmlRoot", "zwei");
        SceneManager.LoadScene("TourScene");
        PlayerPrefs.Save();
    }
    public void SwitchSceneT()
    {
        PlayerPrefs.SetString("xmlRoot", "test");
        SceneManager.LoadScene("TourScene");
        PlayerPrefs.Save();
    }

   /* public void HugoAppears()
    {
        
    }*/

    public void HugoGoesBack()
    {

    }
   /* public void LoadSettings()
    {
        test = PlayerPrefs.GetString("xmlRoot");
        Debug.Log(test);



    }*/
}
