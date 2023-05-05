using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDepot
{
    //Constantes et statique
    public static List<ZoneDepot> zonesDepots = new List<ZoneDepot>();
    public const string NOMOBJET_CAMERA = "Main Camera Player";
    public const string NOMOBJET_JOUEUR = "RPG_Boy";
    public const string NOMOBJET_CONTENT_OBJETS_COLLECTABLE = "ObjetsCollectables";
    public const string NOMOBJET_MODELE_ZONEDEPOT_TITRE = "Modele_Texte_Titre";
    public const string NOMOBJET_MODELE_ZONEDEPOT_INFO = "Modele_Texte_Info";

    //Champs
    private string nomObjetZoneDepot;
    private string nomObjetRecompenseContent;
    private List<ObjetsZoneDepot> objetsPourMission;
    private List<string> listeObjetsDansAZone;
    private string nomMission;
    private string nomScene;
    private bool acheve;
    private int numeroMission;
    private string titreMission;

    //Propriétes
    public string NomObjetZoneDepot { get => nomObjetZoneDepot; set => nomObjetZoneDepot = value; }
    public string NomObjetRecompenseContent { get => nomObjetRecompenseContent; set => nomObjetRecompenseContent = value; }
    public List<ObjetsZoneDepot> ObjetsPourMission { get => objetsPourMission; set => objetsPourMission = value; }
    public List<string> ListeObjetsDansAZone { get => listeObjetsDansAZone; set => listeObjetsDansAZone = value; }
    public string NomMission { get => nomMission; set => nomMission = value; }
    public bool Acheve { get => acheve; set => acheve = value; }
    public string NomScene { get => nomScene; set => nomScene = value; }
    public int NumeroMission { get => numeroMission; set => numeroMission = value; }
    public string TitreMission { get => titreMission; set => titreMission = value; }


    //Constructeur
    public ZoneDepot(string pNomMission, string pNomScene, string pNomObjetZoneDepot, string pNomObjetRecompenseContent, List<ObjetsZoneDepot> pObjetsPourMission, int pNumeroMission, string pTitreMission)
    {
        this.NomObjetZoneDepot = pNomObjetZoneDepot;
        this.NomObjetRecompenseContent = pNomObjetRecompenseContent;
        this.ObjetsPourMission = pObjetsPourMission;
        this.ListeObjetsDansAZone = new List<string>();
        this.NomMission = pNomMission;
        this.acheve = false;
        this.NomScene = pNomScene;
        this.NumeroMission = pNumeroMission;
        this.TitreMission = pTitreMission;
    }

    public void Increment(bool param, ObjetsZoneDepot obj, string nomObjet)
    {
        string nomTag = obj.NomTag;
        //Regarde si l'objet fait parti des éléments de la mission
        ObjetsZoneDepot objetZoneDepot = this.ObjetsPourMission.Find(o => o.NomTag == nomTag);

        if (objetZoneDepot != null)
        {
            //Si on ajoute un élément dans la zone
            if (param)
            {
                GameObject.Destroy(GameObject.Find(nomObjet));
                objetZoneDepot.NbObjetsDansZone++;
                this.ListeObjetsDansAZone.Add(nomObjet);
                if (objetZoneDepot.NbObjetsDansZone == objetZoneDepot.NbObjets)
                {
                    bool missionAccompli = true;
                    foreach (ObjetsZoneDepot o in this.ObjetsPourMission)
                        if (o.NbObjets > o.NbObjetsDansZone)
                            missionAccompli = false;
                    if (missionAccompli)
                    {
                        this.MissionAccompli();
                        GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().desactiveTache(this.NumeroMission);
                        Debug.Log("desactive tache");
                        Debug.Log(GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().listeTaches[numeroMission].Name);
                    }
                }
            }
            //Si un objet sort de la zone
            else
            {
                objetZoneDepot.NbObjetsDansZone--;
                this.ListeObjetsDansAZone.Remove(nomObjet);
            }
            GameObject.Find(this.NomObjetZoneDepot + "_Infos_" + objetZoneDepot.NomObjet).GetComponent<TextMesh>().text = objetZoneDepot.NbObjetsDansZone + "/" + objetZoneDepot.NbObjets;
        }
    }

    //Supprime tous les objets dans la zone de dépot, fait apparaitre l'objet de la mission, supprime les infos et la zone de de dépot
    public void MissionAccompli()
    {
        //Supprime les objets dans la zone        
        foreach (string s in this.ListeObjetsDansAZone)
            GameObject.Destroy(GameObject.Find(s));

        //Affiche l'objet de fin de mission
        GameObject.Find(this.NomObjetRecompenseContent).transform.GetChild(0).gameObject.SetActive(true);

        //Suppirme la zone de depot
        GameObject.Destroy(GameObject.Find(this.NomObjetZoneDepot));

        //Supprime la zone info
        GameObject.Destroy(GameObject.Find(this.NomObjetZoneDepot + "_ContentInfos"));

        this.Acheve = true;
    }
}