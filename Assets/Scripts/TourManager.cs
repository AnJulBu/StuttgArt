using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class TourEvent : UnityEvent<Tour> { }

[System.Serializable]
public class DestinationEvent : UnityEvent<Destination>{ }


public class TourManager : MonoBehaviour
{
    public bool tourAdded = false;
    [SerializeField]
    private List<TextAsset> xmls;
    [SerializeField]
    private List<Tour> tours;
    [SerializeField]
    private Tour currentTour;
    
    private Destination currentDestination;
    [Header("Variablen")]

    [SerializeField]
    private float detectionRange;
    [SerializeField]
    private float destinationRange;
    [Header("Referenzen")]
    [SerializeField]
    private Hugo hugo;
    [SerializeField]
    private MapHandler mapHandler;
    [Header("Events")]
    public TourEvent onStartTour;
    public DestinationEvent onSetDestination;
    public DestinationEvent onDestinationReached;
    public UnityEvent lastDestinationReached;
    // kompletter Header Test muss auskommentiert werden
    /*[Header("Test")]
    [Range(0,50)]
    public float testDistance = 50;
    *///bis hier
    [Header("Content")]
    [SerializeField]
    private List<Sprite> images;
    private void Start()
    {
        XmlReader xmlReader = new XmlReader();
        foreach(TextAsset xml in xmls)
        {
            Tour tour = xmlReader.ReadXml(xml);
            foreach(Destination destination in tour.destinations)
            { 
                List <Sprite> img = images.Where<Sprite>(i => i.name == destination.ImageName).ToList();
                if (img.Count() == 0) continue;
                destination.Image = img.First();
                
                
            }
            tours.Add(tour);

        }
        
    }
    private void Update()
    {
        if (currentTour == null) return;
        if (currentDestination == null)
        {
            if (currentTour.destinations.Count() == 0 && tourAdded == true)
            {
                lastDestinationReached.Invoke();
                currentTour = null;
                return;
            }
            if (currentTour.destinations.Count() == 0 )
            {
               
                currentTour = null;
                return;
            }
            currentDestination = currentTour.destinations[0];
            currentTour.destinations.RemoveAt(0);
            onSetDestination.Invoke(currentDestination);
        }
        // Check distance to destinations  muss einkommentiert werden
         float distance = mapHandler.GetDistance(currentDestination.location);
        //muss auskommentiert werden
         //float distance = testDistance;
        //bis hier 
        if (distance < destinationRange)
        {   //TestDistance muss auskommentiert werden
            //testDistance = 50;
            // bis hier 
            onDestinationReached.Invoke(currentDestination);
        //    currentDestination = null;
        }
        else if(distance < detectionRange)
        {
            // Trigger Hugo 
            hugo.show();
           

        }
        else
        {
            hugo.hide();
        }
    }
    public void showNextDestination()
    {
        currentDestination = null;
    }
    public void  StartTour(string id)
    {
        currentDestination = null;
        currentTour = null;
        Tour baseTour = null;
        foreach (Tour t in tours)
        {   
            if(t.Id == id)
            {
                baseTour = t;
            }
        }

        if (baseTour == null) return;
        Tour tour = new Tour();
        tour.Id = baseTour.Id;
        tour.Description = baseTour.Description;
        foreach(Destination destination in baseTour.destinations)
        {
            tour.destinations.Add(destination);
        }
        currentTour = tour;
        tourAdded = true;
        onStartTour.Invoke(tour);
    }

    // setTest muss auskommentiert werden
    /*public void setTest(float value)
    {
        testDistance = value;
    } */// bis hier
    public void setTourAdded()
    {
        this.tourAdded = false;
    }
}
