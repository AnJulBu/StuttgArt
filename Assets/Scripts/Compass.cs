/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Android;



public class Compass : MonoBehaviour
{


    public Destination destination;
    


    
 
    // private Bool for Gps updation
    private bool gpsIsUpdating;
    private float distanceToTargetLeft;

    private bool hasPermission = false;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(RequestPermissions());
    }
    void Update()
    {
        if (!hasPermission) return;
        //fehler
        //GetLocation();
        // Set the updated distance in distanceToTargetLeft 
      //  this.distanceToTargetLeft = distanceToTarget(latitudeL, longitudeL, latitudeT, longitudeT);


        //Unity Event ausl?sen/delegate 
        // Checks if you are 20 m near the final destination
        if (distanceToTargetLeft < 20)
        {
            Debug.Log("Ziel erreicht");
        }

        // Check if Gps is updating if not update

        // fehler

        // if(!gpsIsUpdating)
        //{
        //    StartCoroutine(GetLocation());
        //    gpsIsUpdating = !gpsIsUpdating;
        //}
        
       // fehler 
        //float bearing = angleFromCoordinate(52.48417657449829f, 13.38643796959971f,
        //    latitudeL, longitudeL);
        // fehler
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, Input.compass.magneticHeading + bearing), 100f);
       

    }
    public float GetDistance(Location destination)
    {
        return distanceToTarget(GetCurrentLocation(),destination);
    }
    //compute the distance between two given latitude and two given longitude
    private static float distanceToTarget(Location currentDeg ,Location targetDeg)
    {
        // if the location is the same return zero 
        if(currentDeg.Latitude == targetDeg.Latitude && currentDeg.Longitude == targetDeg.Longitude)
        {
            return 0;
        }
        
           // compute theta
        float theta = currentDeg.Longitude - targetDeg.Longitude;
        Location currentRad = currentDeg.ToRad();
        Location targetRad = targetDeg.ToRad();
        theta *= Mathf.Deg2Rad;

        //compute Distance in m
        float distanceToTarget = Mathf.Sin(currentRad.Latitude) * Mathf.Sin(targetRad.Latitude) + Mathf.Cos(currentRad.Latitude) * Mathf.Cos(targetRad.Latitude) * Mathf.Cos(theta);
        distanceToTarget = Mathf.Acos(distanceToTarget);
        distanceToTarget *= Mathf.Rad2Deg;
        // vielleicht Math.pi/2
        distanceToTarget = distanceToTarget * 60f * 1.1515f * 1.609344f * 1000;
        // Debug Prints
        Debug.Log(distanceToTarget);
        print(distanceToTarget);

        // return distance between the two Points in meters as a float
        return distanceToTarget;
        
    }
    private float angleFromCoordinate(Location currentDeg, Location targetDeg)
    {
        Location currentRad = currentDeg.ToRad();
        Location targetRad = targetDeg.ToRad();

        float dLon = (targetRad.Longitude - currentRad.Longitude);
        float y = Mathf.Sin(dLon) * Mathf.Cos(targetRad.Longitude);
        float x = (Mathf.Cos(currentRad.Latitude) * Mathf.Sin(targetRad.Latitude)) - (Mathf.Sin(currentRad.Latitude) * Mathf.Cos(targetRad.Latitude) * Mathf.Cos(dLon));
        float brng = Mathf.Atan2(y, x);
        brng = Mathf.Rad2Deg * brng;
        brng = (brng + 360) % 360;
        brng = 360 - brng;
        return brng;
    }

    private Location GetCurrentLocation() 
    {
        Location location = new Location();
        location.Latitude = Input.location.lastData.latitude;
        
        location.Longitude = Input.location.lastData.longitude;
        return location;
    }


  
    IEnumerator RequestPermissions()
    {
        //Check if userpermission for Gps is set if not ask for it 
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            Permission.RequestUserPermission(Permission.CoarseLocation);
        }

        if (!Input.location.isEnabledByUser)
            yield return new WaitForSeconds(10);

        Input.location.Start();

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }
        // if Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            Debug.Log("Timed Out");
        }
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determinate GPS");
        }
        else
        {
            hasPermission = true;
        }
    }
    /*  IEnumerator GetLocation()
      {   
          //Check if userpermission for Gps is set if not ask for it 
          if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
          {
              Permission.RequestUserPermission(Permission.FineLocation);
              Permission.RequestUserPermission(Permission.CoarseLocation);
          }

              if (!Input.location.isEnabledByUser)
              yield return new WaitForSeconds(10);

          Input.location.Start();

          int maxWait = 20;
          while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
          {
              yield return new WaitForSeconds(1);
              maxWait--;
          }
          // if Service didn't initialize in 20 seconds
          if (maxWait < 1)
          {
              Debug.Log("Timed Out");
          }
          if(Input.location.status == LocationServiceStatus.Failed)
          {
              Debug.Log("Unable to determinate GPS");
          }
          else
          {
              this.latitudeL = Input.location.lastData.latitude;
              this.longitudeL = Input.location.lastData.longitude;

          }
      }*/
//}
  