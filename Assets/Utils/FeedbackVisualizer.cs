using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FeedbackVisualizer : MonoBehaviour
{

    public SFXUpload sfxUpload;

    void Start()
    {
        sfxUpload.onFeedback += ShowFeedback;
    }

    private void ShowFeedback(string feedback)
    {
        Debug.Log("Foo");
        GetComponent<TMP_Text>().text = feedback;
    }


}
