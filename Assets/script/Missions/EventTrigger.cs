using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider))]

public class EventTrigger : MonoBehaviour
{
    public UnityEvent onTrigger;

    void Awake()
    {
        if (onTrigger == null)
            onTrigger = new UnityEvent();
    }

    //Déclencher quand un élément rentre en colision avec la zone de spawn quand il rentre
    void OnTriggerEnter(Collider other)
    {
        //Si il y a une colision avec un objet de la zone
        foreach (ZoneDepot e in ZoneDepot.zonesDepots)
            if (e.NomScene == SceneManager.GetActiveScene().name)
                foreach (ObjetsZoneDepot ozd in e.ObjetsPourMission)  
                    if (other.tag == GameObject.Find(ozd.NomObjet).tag && transform.name == e.NomObjetZoneDepot)                
                        e.Increment(true, ozd, other.name);     
    }

    //Déclencher quand un élément rentre en colision avec la zone de spawn quand il sort
    private void OnTriggerExit(Collider other)
    {
        //Si il y a une colision avec un objet de la zone
        foreach (ZoneDepot e in ZoneDepot.zonesDepots)
            if (e.NomScene == SceneManager.GetActiveScene().name)
                foreach (ObjetsZoneDepot ozd in e.ObjetsPourMission)
                    if (other.tag == GameObject.Find(ozd.NomObjet).tag && transform.name == e.NomObjetZoneDepot)
                        e.Increment(false, ozd, other.name);
    }

}
