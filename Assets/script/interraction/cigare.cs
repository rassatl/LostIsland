using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cigare : MonoBehaviour
{
    public string namePlayer;
    public GameObject cigareObjet;
    public GameObject cigareObjetSquellette;
    public Item cigareItem;
    private GameObject inventoryManager;

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager");
    }
    void OnTriggerStay(Collider leCollider)
    {
        if (leCollider.name == namePlayer)
        {
            if (Input.GetKeyDown("e") && !(leCollider.GetComponent<Player>().goldCigare))
            {
                GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().desactiveTache(11); //desactive la tache 
                leCollider.GetComponent<Player>().goldCigare = true;
                inventoryManager.GetComponent<InventoryManager>().UpdateInventory(cigareItem); //pour l'inventaire
                inventoryManager.GetComponent<InventoryManager>().ListItems();
                Destroy(cigareObjet);
                cigareObjetSquellette.SetActive(true);
            }
        }
    }
    void OnTriggerEnter(Collider leCollider)
    {
        if (leCollider.name == namePlayer)
        {
            leCollider.transform.GetChild(11).gameObject.SetActive(true);
            if (!(leCollider.GetComponent<Player>().goldCigare))
            {
                GameObject.Find("tacheCanvas").GetComponent<GestionnaireTaches>().activeTache(11); //active la tache (si pas encore activé)

                leCollider.transform.GetChild(10).gameObject.SetActive(true);
                leCollider.transform.GetChild(10).gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Prendre le cigare (E)";

                leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Ho le cigare !";
            }


        }
    }
    void OnTriggerExit(Collider leCollider)
    {
        if (leCollider.name == namePlayer)
        {
            leCollider.transform.GetChild(10).gameObject.SetActive(false);
            leCollider.transform.GetChild(11).gameObject.SetActive(false);
        }
    }
}
