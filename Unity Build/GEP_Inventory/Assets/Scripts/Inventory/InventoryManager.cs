using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public string inventory_type;

    public List<Item> inventory_list = new List<Item>();
    public Transform list_content;
    public GameObject list_object;

    private void Awake()
    {
        inventory_type = "List";

        list_content = GameObject.Find("Content(List)").GetComponent<Transform>();
    }

    public void AddItem(Item item)
    {
        if (inventory_type == "List")
        {
            inventory_list.Add(item);
        }
        CreateInventory();
    }

    public void RemoveItem(Item item)
    {
        if (inventory_type == "List")
        {
            inventory_list.Remove(item);
        }
        CreateInventory();
    }

    public void CreateInventory()
    {
        if (inventory_type == "List")
        {
            if (list_content.childCount != 0)
            {
                for (int i = 0; i < list_content.childCount; i++)
                {
                    Destroy(list_content.GetChild(i).gameObject);
                }
            }

            for (int i = 0; i < inventory_list.Count; i++)
            {
                GameObject item_ui = Instantiate(list_object, list_content) as GameObject;
                item_ui.transform.name = "ItemButton(List)";

                TextMeshProUGUI item_ui_name = item_ui.transform.Find("ItemName(List)").GetComponent<TextMeshProUGUI>() as TextMeshProUGUI;
                item_ui_name.text = inventory_list[i].item_name;
            }
        }
    }
}