using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemController : MonoBehaviour
{
   public Item itemRowChicken;
    public Item itemChicken;
    public Item itemFlint;
    public Item itemCigare;
    private Item item;

    void Start()
    {
        if (this.name == "RowChicken")
            item = itemRowChicken;
        else if (this.name == "Chicken")
            item = itemChicken;

        switch(this.name)
        {
            case "RowChicken":
                item = itemRowChicken;
                break;
            case "Chicken":
                item = itemChicken;
                break;
            case "Flint":
                item = itemFlint;
                break;
            case "Cigare":
                item = itemCigare;
                break;
        }

    }

    //méthode qui remove
    public void RemoveItem()
    {
        InventoryManager.Instance.Remove(item);
        Destroy(gameObject);
    }

    //méthode qui add
    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    //méthode qui utilise l'item
    public void UseItem()
    {
        print("okiiiiii");
        switch (item.itemType)
        {
            case Item.ItemType.RowChicken:
                print("utilisation d'un raw chicken");
                PlayerH.Instance.soins(item.value);
                break;
            case Item.ItemType.Chicken:
                print("utilisation d'un chicken cuit");
                PlayerH.Instance.soins(item.value);
                break;
        }
        RemoveItem();
    }

}
