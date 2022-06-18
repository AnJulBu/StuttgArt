using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

public class XmlReader 
{
   
    public Tour ReadXml(TextAsset file)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load(new StringReader(file.text));
        string xmlPathPattern = "//tour/artposition";
        XmlNodeList myNodeList = xmlDoc.SelectNodes(xmlPathPattern);


        Tour tour = new Tour();
         string xmlPathPattern1 = "//tour";
        XmlNodeList myNodeList1 = xmlDoc.SelectNodes(xmlPathPattern1);
        foreach (XmlElement node in myNodeList1)
        {
            tour.Id=node.GetAttribute("id");
            tour.Description = node.SelectSingleNode("einführungGeschichte").InnerText;
        }
            foreach (XmlElement node in myNodeList)
        {
            Destination destination = new Destination();
            
            destination.Id = node.GetAttribute("id");
            destination.GeoId = node.GetAttribute("geoId");
            destination.TourId = node.GetAttribute("tourId");
            destination.location.Latitude = float.Parse(node.GetAttribute("lat"));
            destination.location.Longitude = float.Parse(node.GetAttribute("long"));
            destination.OneLiner = node.SelectSingleNode("einzeilerKompass").InnerText;
            destination.HintPoem1 = node.SelectSingleNode("hinweisGedicht1").InnerText;
            // destination.hintPoem2 = node.SelectSingleNode("hintPoem2").InnerText;
            destination.ArtInfo1 = node.SelectSingleNode("werkInfos1").InnerText;
            // destination.artInfo2 = node.SelectSingleNode("werkInfos2").InnerText;
            destination.Story1 = node.SelectSingleNode("geschichte1").InnerText;
           // destination.Story2 = node.SelectSingleNode("geschichte2").InnerText;
            destination.ImageName = node.SelectSingleNode("img").InnerText;
            tour.destinations.Add(destination);
            
        }
            return tour;
    }
}
