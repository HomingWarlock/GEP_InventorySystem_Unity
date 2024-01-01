using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{
    public GameObject list_inventory;
    public bool inventory_open;
    public bool inventory_delay;

    void Start()
    {
        list_inventory = GameObject.Find("Inventory(List)");
        list_inventory.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        inventory_open = false;
        inventory_delay = false;
    }

    void Update()
    {
        //Debug Locks Below
        if (Input.GetKey(KeyCode.Z))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKey(KeyCode.X))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        //Debug Locks Above

        if (Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.I))
        {
            if (!inventory_open && !inventory_delay)
            {
                list_inventory.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                inventory_delay = true;
                StartCoroutine(InventoryToggleDelay());
            }
            else if (inventory_open && !inventory_delay)
            {
                list_inventory.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                inventory_delay = true;
                StartCoroutine(InventoryToggleDelay());
            }
        }
    }

    public IEnumerator InventoryToggleDelay()
    {
        yield return new WaitForSeconds(0.2f);

        inventory_delay = false;

        if (!inventory_open) { inventory_open = true; }
        else if (inventory_open) { inventory_open = false; }
    }
}
