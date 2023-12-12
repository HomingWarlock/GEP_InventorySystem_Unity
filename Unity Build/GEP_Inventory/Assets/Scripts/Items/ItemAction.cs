using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAction : MonoBehaviour
{
    private InventoryManager inventory_manager;
    public Item item;

    private void Awake()
    {
        inventory_manager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Player")
        {
            PickUp();
        }
    }

    private void PickUp()
    {
        inventory_manager.AddItem(item);
        Destroy(this.gameObject);
    }
}