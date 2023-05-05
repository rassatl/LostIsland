using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerateObjects : MonoBehaviour
{
    public int NumeroScene;
    // Start is called before the first frame update
    void Start()
    {
        /*----------------------------*/
        /*      Les zones de dépots   */
        /*----------------------------*/

        string nomScene = SceneManager.GetActiveScene().name;
        if (nomScene == "Scene1")
        {
            if (ZoneDepot.zonesDepots.Find(o => o.NomMission == "TENTE" && o.Acheve == true) == null && !GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().listeTaches[0].Fait)
            {
                //Création de la tente
                List<ObjetsZoneDepot> objets_Tente = new List<ObjetsZoneDepot>();
                //objets_Tente.Add(new ObjetsZoneDepot("Modele_Bois", 2));
                objets_Tente.Add(new ObjetsZoneDepot("Modele_Toile", 1));
                ZoneDepot.zonesDepots.Add(new ZoneDepot("TENTE", nomScene, "ZoneDepot_Tente", "FinMission_Tente", objets_Tente, 1, "Mission Tente"));
            }
            else
                ZoneDepot.zonesDepots.Find(o => o.NomMission == "TENTE").MissionAccompli();


            if (ZoneDepot.zonesDepots.Find(o => o.NomMission == "BATEAU" && o.Acheve == true) == null && !GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().listeTaches[1].Fait)
            {
                //Création du bateau
                List<ObjetsZoneDepot> objets_Bateau = new List<ObjetsZoneDepot>();
                objets_Bateau.Add(new ObjetsZoneDepot("Modele_Bois", 10));
                ZoneDepot.zonesDepots.Add(new ZoneDepot("BATEAU", nomScene, "ZoneDepot_Bateau", "FinMission_Bateau", objets_Bateau, 2, "Mission Bateau"));

            }
            else
                ZoneDepot.zonesDepots.Find(o => o.NomMission == "BATEAU").MissionAccompli();

            //Ajoute de la toile 
            ZonesSpawn.zonesSpawns.Add(new ZonesSpawn("ZoneSpawn_Toile", nomScene, 1, "Modele_Toile"));
        }
        else if (nomScene == "Scene2")
        {
            if (ZoneDepot.zonesDepots.Find(o => o.NomMission == "BATEAU_2" && o.Acheve == true) == null && !GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().listeTaches[8].Fait)
            {
                //Création du bateau 2
                List<ObjetsZoneDepot> objets_Bateau2 = new List<ObjetsZoneDepot>();
                objets_Bateau2.Add(new ObjetsZoneDepot("Modele_Bois", 10));
                ZoneDepot.zonesDepots.Add(new ZoneDepot("BATEAU_2", nomScene, "ZoneDepot_Bateau2", "FinMission_Bateau2", objets_Bateau2, 8, "Mission Bateau"));
            }
            else
                ZoneDepot.zonesDepots.Find(o => o.NomMission == "BATEAU_2").MissionAccompli();

            //Ajoute du bois 
            ZonesSpawn.zonesSpawns.Add(new ZonesSpawn("ZoneSpawn_Bois", nomScene, 15, "Modele_Bois"));


        }
        else if (nomScene == "Scene4")
        {

            if (ZoneDepot.zonesDepots.Find(o => o.NomMission == "SOS" && o.Acheve == true) == null && !GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().listeTaches[11].Fait)
            {
                //Création du SOS
                List<ObjetsZoneDepot> objets_SOS = new List<ObjetsZoneDepot>();
                objets_SOS.Add(new ObjetsZoneDepot("Modele_Pierre", 5));
                ZoneDepot.zonesDepots.Add(new ZoneDepot("SOS", nomScene, "ZoneDepot_SOS", "FinMission_SOS", objets_SOS, 12, "Mission Bateau Sos"));
            }
            else
                ZoneDepot.zonesDepots.Find(o => o.NomMission == "SOS").MissionAccompli();
            //Ajoute des pierres 
            ZonesSpawn.zonesSpawns.Add(new ZonesSpawn("ZoneSpawn_Pierre", nomScene, 20, "Modele_Pierre"));
        }
        
        //Génére chaque zone de dépot
        foreach (ZoneDepot e in ZoneDepot.zonesDepots)
            if (e.NomScene == nomScene)
                GenerateZoneDepot(e);

        /*----------------------------*/
        /*      Les zones de spawn    */
        /*----------------------------*/


        //Génère chaque zone de spawn
        foreach (ZonesSpawn e in ZonesSpawn.zonesSpawns)
            if (e.NomScene == nomScene)
                GenerateZoneSpawn(e);

    }

    public void GenerateZoneDepot(ZoneDepot e)
    {

        GameObject zoneDepot = GameObject.Find(e.NomObjetZoneDepot);

        //Creation content titre
        GameObject objToSpawn = new GameObject(e.NomObjetZoneDepot + "_ContentInfos");
        objToSpawn.transform.parent = GameObject.Find(e.NomObjetZoneDepot).transform;

        /*Création du titre*/
        GameObject titre = MonoBehaviour.Instantiate(GameObject.Find(ZoneDepot.NOMOBJET_MODELE_ZONEDEPOT_TITRE));
        titre.GetComponent<TextMesh>().text = e.TitreMission;
        titre.transform.name = e.NomObjetZoneDepot + "_Titre";
        titre.transform.position = new Vector3(zoneDepot.transform.position.x, zoneDepot.transform.position.y + zoneDepot.transform.lossyScale.y / 2 + 1, zoneDepot.transform.position.z - titre.transform.lossyScale.z / 2);
        titre.transform.parent = objToSpawn.transform;

        //Pour chaque objets pour la mission mettre un aperçu de l'objet + la progression
        for (int i = 0; i < e.ObjetsPourMission.Count; i++)
        {
            /*Création d'un sous titre*/
            GameObject sousTitre = MonoBehaviour.Instantiate(GameObject.Find("Modele_Texte_Info"));
            sousTitre.GetComponent<TextMesh>().text = e.ObjetsPourMission[i].NbObjetsDansZone + "/" + e.ObjetsPourMission[i].NbObjets;
            sousTitre.transform.name = e.NomObjetZoneDepot + "_Infos_" + e.ObjetsPourMission[i].NomObjet;
            sousTitre.transform.position = new Vector3(zoneDepot.transform.position.x, zoneDepot.transform.position.y + zoneDepot.transform.lossyScale.y / 2 + (0.5f * i), zoneDepot.transform.position.z - sousTitre.transform.lossyScale.z / 2 - 0.5f);
            sousTitre.transform.parent = objToSpawn.transform;

            /*Création modèle réduit*/
            GameObject modeleReduit = MonoBehaviour.Instantiate(GameObject.Find(e.ObjetsPourMission[i].NomObjet + "_Reduit"));
            modeleReduit.transform.name = e.NomObjetZoneDepot + "_" + e.ObjetsPourMission[i].NomObjet;
            modeleReduit.transform.position = new Vector3(zoneDepot.transform.position.x, zoneDepot.transform.position.y + zoneDepot.transform.lossyScale.y / 2 + (0.25f * i), zoneDepot.transform.position.z - sousTitre.transform.lossyScale.z / 2);
            modeleReduit.transform.parent = objToSpawn.transform;
        }
    }
    public void GenerateZoneSpawn(ZonesSpawn e)
    {
        GameObject boxContentSpawn = GameObject.Find(e.NomObjetZoneSpawn);
        GameObject objetPrefab = GameObject.Find(e.NomObjet);

        float[] posZoneSpawn = new float[] { boxContentSpawn.transform.position.x - boxContentSpawn.transform.lossyScale.x / 2, boxContentSpawn.transform.position.x + boxContentSpawn.transform.lossyScale.x / 2, boxContentSpawn.transform.position.z - boxContentSpawn.transform.lossyScale.z / 2, boxContentSpawn.transform.position.z + boxContentSpawn.transform.lossyScale.z / 2 };

        List<GameObject> listeObjets = new List<GameObject>();
        for (int i = 0; i < e.NbObjets; i++)
        {
            listeObjets.Add(MonoBehaviour.Instantiate(objetPrefab));
            listeObjets[i].name = listeObjets[i].tag + "_" + i;
            listeObjets[i].transform.position = new Vector3(Random.Range(posZoneSpawn[0], posZoneSpawn[1]), boxContentSpawn.transform.position.y - listeObjets[i].transform.lossyScale.y, Random.Range(posZoneSpawn[2], posZoneSpawn[3]));
            listeObjets[i].AddComponent<PickableObject>();
            listeObjets[i].GetComponent<PickableObject>().player = GameObject.Find(ZoneDepot.NOMOBJET_JOUEUR).transform;
            listeObjets[i].GetComponent<PickableObject>().playerCam = GameObject.Find(ZoneDepot.NOMOBJET_CAMERA).transform;
            listeObjets[i].transform.parent = GameObject.Find(ZoneDepot.NOMOBJET_CONTENT_OBJETS_COLLECTABLE).transform;
        }


    }
}
