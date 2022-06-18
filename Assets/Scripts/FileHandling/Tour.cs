using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class Tour 
{
    public string Id;
    public string Description;
    public List<Destination> destinations =new List<Destination>();
}

[Serializable]
public class Destination
{
    public string Id;
    public string GeoId;
    public string TourId;
    public string OneLiner;
    public string HintPoem1;
    //public string HintPoem2;
    public string ArtInfo1;
    //public string ArtInfo2;
    public string Story1;
    //public string Story2;
    public string ImageName;
    public Location location = new Location();
   // public string Description;
    public Sprite Image;
   // public string Poem;
} 