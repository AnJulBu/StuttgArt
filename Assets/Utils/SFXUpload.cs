using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using Recorder;
using UnityEngine.Events;
using UnityEditor;


public class SFXUpload : MonoBehaviour
{
    public delegate void UploadFeedback(string feedback);
    public UploadFeedback onFeedback;

    public delegate void UploadEvent();
    public UploadEvent onUploadCompleted;

    [SerializeField, Tooltip("URL to the upload script")]
    string url = "Server link , The server will provide ！";
    private Destination destination;
    /// <summary>
    ///  Upload to server 
    /// </summary>
    public void SetContent(Destination destination)
    {
        this.destination = destination;
    }
    public void UploadToServer()
    {
        // Todo: Get the stuff from your code!
        string filePath = Recorder.Recorder.GetRecordedFile();
        //string filePath = Path.Combine(Application.persistentDataPath,"recording.wav") ;

        //FileUtil.CopyFileOrDirectory(Recorder.Recorder.GetRecordedFile(), filePath);
        //File.Copy(Recorder.Recorder.GetRecordedFile(), filePath);
        //onFeedback?.Invoke(filePath);

        string geoID = destination.GeoId;

        onFeedback?.Invoke("Upload in progress");
        StartCoroutine(UploadVideo(filePath, geoID));
    }

    //  Upload video 
    IEnumerator UploadVideo(string filePath, string geoID)
    {
        onFeedback?.Invoke("Started Upload: " + filePath);

        byte[] bytes = File.ReadAllBytes(filePath);
        WWWForm form = new WWWForm();

        // Modify the format according to your own long-term documents 
        form.AddBinaryData("fileToUpload", bytes, "recording.wav", "audio/wav");
        form.AddField("geo_id", geoID);

        Debug.Log(url);
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {

            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError ||
                www.result == UnityWebRequest.Result.ProtocolError) 
            {
                Debug.Log(www.error);
                onFeedback?.Invoke("An error occured during upload");
            }
            else
            {
                string text = www.downloadHandler.text;
                Debug.Log(" Server return value " + text);// Print server return value correctly 
                onFeedback?.Invoke("Upload successful");
                onUploadCompleted?.Invoke();
            }
        }
    }



}
