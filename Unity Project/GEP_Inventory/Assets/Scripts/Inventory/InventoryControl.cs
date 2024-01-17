using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{
    public PlayerScript player_script;

    public GameObject crosshair_ui;

    public bool inventory_open;
    public bool inventory_delay;

    public GameObject list_inventory;

    void Start()
    {
        player_script = GetComponent<PlayerScript>();

        crosshair_ui = GameObject.Find("Crosshair");
        crosshair_ui.SetActive(true);

        inventory_open = false;
        inventory_delay = false;

        list_inventory = GameObject.Find("Inventory(List)");
        list_inventory.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.I))
        {
            if (!inventory_open && !inventory_delay)
            {
                list_inventory.SetActive(true);
                crosshair_ui.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                player_script.movement_locked = true;
                inventory_delay = true;
                StartCoroutine(InventoryToggleDelay());
            }
            else if (inventory_open && !inventory_delay)
            {
                list_inventory.SetActive(false);
                crosshair_ui.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
                player_script.movement_locked = false;
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
