using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class silexInterraction : MonoBehaviour
{
    public string namePlayer;
    private GameObject inventoryManager;
    public Item silexItem;

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
                inventoryManager.GetComponent<InventoryManager>().UpdateInventory(silexItem); //pour l'inventaire
                inventoryManager.GetComponent<InventoryManager>().ListItems();

                leCollider.GetComponent<Player>().nbSilex++;
                leCollider.transform.GetChild(11).gameObject.SetActive(true);
                leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Et hop un silex en plus !";
            }
        }
    }
    void OnTriggerEnter(Collider leCollider)
    {
        if (leCollider.name == namePlayer)
        {
            if(leCollider.GetComponent<Player>().maitreDuFeu > 0)
            {
                leCollider.transform.GetChild(10).gameObject.SetActive(true);
                leCollider.transform.GetChild(10).gameObject.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "Récupérer un silex (E)";
            }
            else
            {
                leCollider.transform.GetChild(11).gameObject.SetActive(true);
                leCollider.transform.GetChild(11).transform.GetChild(1).GetComponent<UnityEngine.UI.Text>().text = "J'ai l'impression que je pourrais utiliser ces pierres mais je sais pas pourquoi...";
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
