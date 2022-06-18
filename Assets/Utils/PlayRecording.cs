
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using Recorder;
using UnityEngine.Events;
using UnityEngine.Networking;


public class PlayRecording : MonoBehaviour
{

    public UnityEvent playingStarted;
    public UnityEvent playingEnded;

    [SerializeField]
    private AudioSource audioSource;

    public void StartPlaying()
    {
        playingStarted?.Invoke();
        StartCoroutine(PlayRecord());
    }

    public void StartLoading()
    {
        StartCoroutine(LoadAudio());
    }

    // Loading the audio from the streamingAssets-Folder using UnityNetworking in an own thread!
    private IEnumerator LoadAudio()
    {
        // See https://docs.unity3d.com/ScriptReference/Networking.UnityWebRequestMultimedia.GetAudioClip.html
        using (UnityWebRequest www = UnityWebRequestMultimedia.GetAudioClip("file://" + Recorder.Recorder.GetRecordedFile(), AudioType.WAV))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(www.error);
            }
            else
            {
                AudioClip myClip = DownloadHandlerAudioClip.GetContent(www);
                audioSource.clip = myClip;
            }
        }
    }

    private IEnumerator PlayRecord()
    {
        if (audioSource.clip != null)
        {
            audioSource.Play(0);
            yield return new WaitForSeconds(audioSource.clip.length -1);
            playingEnded?.Invoke();
        }
    }

}
