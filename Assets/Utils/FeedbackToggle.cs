using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class FeedbackToggle : MonoBehaviour
{

    [SerializeField, Tooltip("Gameobject containing all elements for the audio recording button.")]
    private GameObject recordBtn;

    [SerializeField, Tooltip("Gameobject containing all elements for the audio recording process feedback")]
    private GameObject recordingFeedback;

    [SerializeField, Tooltip("Gameobject cointaining the play button for reviewing the audio record")]
    private GameObject playBtn;

    [SerializeField, Tooltip("Gameobject used for uploading the recording to the server")]
    private GameObject uploadBtn;

    [SerializeField, Tooltip("Gameobject used for textual feedback on when the recording starts, maybe replace by fancy animation?")]
    private GameObject pressFeedback;

    [SerializeField, Tooltip("Gameobject used for the upload feedback.")]
    private GameObject uploadFeedback;

    void Start()
    {
        uploadBtn.GetComponent<SFXUpload>().onFeedback += SetUploadFeedback;
        uploadBtn.GetComponent<SFXUpload>().onUploadCompleted += Reset;
    }

    public void ShowPressFeedback()
    {
        pressFeedback.gameObject.SetActive(true);
        uploadFeedback.gameObject.SetActive(false);
    }

    public void HidePressFeedback()
    {
        pressFeedback.gameObject.SetActive(false);
    }

    public void OnRecordingStarted()
    {
        recordBtn.GetComponent<KeepPressedButton>().interactable = false;
        recordingFeedback.gameObject.SetActive(true);
        //recordingFeedback.GetComponentInChildren<SliderAnimation>().StartAnimation();
        HidePressFeedback();
        playBtn.SetActive(false);
        uploadBtn.SetActive(false);
    }

    public void OnRecordingEnded()
    {
        recordingFeedback.gameObject.SetActive(false);
        recordBtn.GetComponent<KeepPressedButton>().interactable = true;
        HidePressFeedback();
        playBtn.SetActive(true);
        uploadBtn.SetActive(true);
    }

    public void Reset()
    {
        recordBtn.SetActive(true);
        recordingFeedback.gameObject.SetActive(false);
        playBtn.SetActive(false);
        uploadBtn.SetActive(false);
    }

    public void DeactivateInput()
    {
        recordBtn.GetComponent<KeepPressedButton>().interactable = false;
        playBtn.GetComponent<Button>().interactable = false;
        uploadBtn.GetComponent<Button>().interactable = false;
    }

    public void ActivateInput()
    {
        recordBtn.GetComponent<KeepPressedButton>().interactable = true;
        playBtn.GetComponent<Button>().interactable = true;
        uploadBtn.GetComponent<Button>().interactable = true;
    }

    public void SetUploadFeedback(string feedback)
    {
        uploadFeedback.gameObject.SetActive(true);
        uploadFeedback.GetComponent<TMP_Text>().SetText(feedback);
    }

}
