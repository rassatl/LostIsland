using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonesSpawn
{
    public static List<ZonesSpawn> zonesSpawns = new List<ZonesSpawn>();

    private string nomObjetZoneSpawn;
    private int nbObjets;
    private string nomObjet;
    private string nomScene;

    public string NomObjetZoneSpawn { get => nomObjetZoneSpawn; set => nomObjetZoneSpawn = value; }
    public int NbObjets { get => nbObjets; set => nbObjets = value; }
    public string NomObjet { get => nomObjet; set => nomObjet = value; }
    public string NomScene { get => nomScene; set => nomScene = value; }

    public ZonesSpawn(string pNomObjetZoneSpawn, string pNomScene, int pNbObjets, string pNomObjet)
    {
        this.NomObjetZoneSpawn = pNomObjetZoneSpawn;
        this.NbObjets = pNbObjets;
        this.NomObjet = pNomObjet;
        this.NomScene = pNomScene;
    }
}
