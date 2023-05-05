using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<Item> items = new List<Item>();
    private List<Item> itemsDiff = new List<Item>();
    private List<int> nbItems;

    //les différents item
    //public Item ItemPouletCru;
    //public Item ItemPoulet;

    public Transform ItemContent;
    public GameObject InventoryItem;

    public GameObject perso;

    public InventoryItemController[] InventoryItems;


    //méthode qui récupere les infos de l'item 
    public void Awake()
    {
        Instance = this;
    }

    public void UpdateInventory(Item it)
    {
        items.Add(it);
        print("ajoute item");
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        print("supprimer");
    }

    //méthode qui liste tous les items
    public void ListItems()
    {
        foreach(Item i in itemsDiff)
        {
            if (items.FindAll(x => x.itemName == i.itemName).Count == 0)
                Destroy(i);
        }
        print("update inventory");
        foreach (Transform item in ItemContent)
            Destroy(item.gameObject);
        nbItems = new List<int>();
        foreach (Item i in items)
            if (itemsDiff.Find(x => x.itemName == i.itemName) == null)
                itemsDiff.Add(i);
        foreach(Item i in itemsDiff)
            nbItems.Add(items.FindAll(x => x.itemName == i.itemName).Count);       
        
        for(int i =0; i<itemsDiff.Count;i++)
        {            
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();
            var nbItem = obj.transform.Find("nbItem").GetComponent<Text>();
            obj.name = itemsDiff[i].itemName;

            itemName.text = itemsDiff[i].itemName;
            itemIcon.sprite = itemsDiff[i].icon;
            nbItem.text = nbItems[i].ToString();

            if (nbItems[i] == 0)
                Destroy(obj);
        }
        SetInventoryItems();
    }

    //méthode qui affiche tous les items dans l'inventaire
    public void SetInventoryItems()
    {
        InventoryItems = ItemContent.GetComponentsInChildren<InventoryItemController>();
        
        for (int i = 0; i < itemsDiff.Count; i++)
        {
            
            InventoryItems[i].AddItem(itemsDiff[i]);

        }
    }
}
