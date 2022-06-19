using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class UiCompass : MonoBehaviour
{
    [SerializeField]
    private MapHandler mapHandler;
    [SerializeField]
    private Transform pole;
    [SerializeField]
    private Transform destinationNeedle;

    private Destination currDestination;
    // Start is called before the first frame update
    void Start()
    {
        Input.compass.enabled = true;
        Input.location.Start();
        //Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {   
        pole.rotation = Quaternion.Lerp(pole.rotation, Quaternion.Euler(0, 0, Input.compass.magneticHeading ), 100f);
        
        if (currDestination == null) return;
        float bearing = mapHandler.getAngle(currDestination.location);
        destinationNeedle.rotation = Quaternion.Lerp(destinationNeedle.rotation, Quaternion.Euler(0, 0, Input.compass.magneticHeading + bearing), 100f);
    }
    public void SetContent(Destination destination)
    {
        currDestination = destination;
    }
}
