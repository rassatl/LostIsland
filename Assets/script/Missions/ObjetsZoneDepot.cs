using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetsZoneDepot
{
    private string nomObjet;
    private string nomTag;
    private int nbObjets;
    private int nbObjetsDansZone;

    public string NomObjet { get => nomObjet; set => nomObjet = value; }
    public int NbObjets { get => nbObjets; set => nbObjets = value; }
    public int NbObjetsDansZone { get => nbObjetsDansZone; set => nbObjetsDansZone = value; }
    public string NomTag { get => nomTag; set => nomTag = value; }

    public ObjetsZoneDepot(string pNomObjet, int pNbObjets)
    {
        this.NomObjet = pNomObjet;
        this.NbObjets = pNbObjets;
        this.NbObjetsDansZone = 0;
    }
}
