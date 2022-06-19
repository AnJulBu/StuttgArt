using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RequestAudio : MonoBehaviour
{
    
    [SerializeField, Tooltip("AudioSource used for playing the audio")]
    private AudioSource audioSource;


    
    
    private Destination destination;
    /// <summary>
    ///  Upload to server 
    /// </summary>
    public void SetContent(Destination destination)
    {
        this.destination = destination;
    }
    

    public void GetAudio(){
        StartCoroutine(GetAudio_Coroutine());
    }

    private IEnumerator GetAudio_Coroutine()
    {

        string url = "http://dh-projekte.uni-tuebingen.de/geocaching/require_audio.php?geo_id=" + destination.GeoId;
        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            yield return request.SendWebRequest();

            if ((request.result == UnityWebRequest.Result.ConnectionError ||
                 request.result == UnityWebRequest.Result.ProtocolError))
            {
                Debug.Log(request.error);
            }
            else
            {
                string audioUrl = request.downloadHandler.text;
                //outputArea.text = audioUrl;
                using (UnityWebRequest audioRequest = UnityWebRequestMultimedia.GetAudioClip(audioUrl, AudioType.WAV))
                {
                    yield return audioRequest.SendWebRequest();

                    if (audioRequest.result == UnityWebRequest.Result.ConnectionError ||
                        audioRequest.result == UnityWebRequest.Result.ProtocolError)
                    {
                        Debug.Log(audioRequest.error);
                    }
                    else
                    {
                        AudioClip clip = DownloadHandlerAudioClip.GetContent(audioRequest);
                        audioSource.clip = clip;
                        audioSource.Play();
                        Debug.Log("Audio is playing");
                    }
                }
            }
        }

    }

    public void playAudio()
    {
        audioSource.Play();
    }
}
