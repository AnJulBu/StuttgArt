using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    [SerializeField]
    private Screen startScreen;
    void Start()
    {
        startScreen.ShowScreen(startScreen);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
