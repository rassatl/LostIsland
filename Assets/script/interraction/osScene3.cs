using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class osScene3 : MonoBehaviour
{
    public string namePlayer;
    private GameObject inventoryManager;
    public Item osItem;


    void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager");

    }

    private void OnTriggerStay(Collider leCollider)
    {
        if (leCollider.name == namePlayer)
        {
            if (Input.GetKeyDown("e"))
            {
                inventoryManager.GetComponent<InventoryManager>().UpdateInventory(osItem); //pour l'inventaire
                inventoryManager.GetComponent<InventoryManager>().ListItems();
                leCollider.GetComponent<Player>().nbOs++;
                leCollider.transform.GetChild(11).gameObject.SetActive(true);
                leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Parfait, il fera l'affaire !";
            }
        }
    }
    void OnTriggerEnter(Collider leCollider)
    {
        if (leCollider.name == namePlayer)
        {
            
            leCollider.transform.GetChild(10).gameObject.SetActive(true);
            leCollider.transform.GetChild(10).gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Récupérer un os (E)";
            
            
            leCollider.transform.GetChild(11).gameObject.SetActive(true);
            leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Peut être que ces os pourraient m'être utile";

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
