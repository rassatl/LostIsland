using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;
    public GameObject perso;
    private GameObject inventoryManager;

    void Start()
    {
        inventoryManager = GameObject.Find("InventoryManager");
        perso = GameObject.Find("Player");
    }

    //méthode qui récupere l'objet sur unity
    void PickUp()
    {
        perso.GetComponent<Player>().nbPouletCru++;
        Destroy(gameObject);
        inventoryManager.GetComponent<InventoryManager>().UpdateInventory(item);
        inventoryManager.GetComponent<InventoryManager>().ListItems();
    }

    private void OnMouseDown()
    {
        PickUp();
    }
}
