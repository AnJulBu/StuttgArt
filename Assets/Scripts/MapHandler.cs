using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class Location
{
    public float Longitude;
    public float Latitude;


    public Location ToRad()
    {
        Location location = new Location();
        location.Longitude *= Mathf.Deg2Rad;
        location.Latitude *= Mathf.Deg2Rad;
        return location;
    }
    public Location ToDeg()
    {
        Location location = new Location();
        location.Longitude *= Mathf.Rad2Deg;
        location.Latitude *= Mathf.Rad2Deg;
        return location;
    }
}
public class MapHandler : MonoBehaviour
{
    private bool hasPermission = false;
    // Start is called before the first frame update
    private void Start()
    {
        StartCoroutine(RequestPermissions());
    }
    public float GetDistance(Location destination)
    {   if (!hasPermission) return float.PositiveInfinity;
        return distanceToTarget(GetCurrentLocation(), destination);
    }
    //compute the distance between two given latitude and two given longitude
    private static float distanceToTarget(Location currentDeg, Location targetDeg)
    {
        // if the location is the same return zero 
        if (currentDeg.Latitude == targetDeg.Latitude && currentDeg.Longitude == targetDeg.Longitude)
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
    public float getAngle(Location destination)
    {
        return angleFromCoordinate(GetCurrentLocation(), destination);
    }
    private Location GetCurrentLocation()
    {
        Location location = new Location();
        location.Latitude = Input.location.lastData.latitude;

        location.Longitude = Input.location.lastData.longitude;
        return location;
    }


    // Update is called once per frame
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
}
