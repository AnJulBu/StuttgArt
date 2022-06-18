using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HugoScreen : MonoBehaviour
{

    [SerializeField]
    private Hugo hugo;
    private void OnEnable()
    {
        hugo.screen = GetComponent<Screen>();
    }
    private void OnDisable()
    {
        hugo.screen = null;
    }
}
