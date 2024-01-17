using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ItemGrab : MonoBehaviour
{
    private InventoryManager inventory_manager;
    private Camera cam;
    private LayerMask mask;

    private void Awake()
    {
        inventory_manager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
        cam = GetComponent<Camera>();
        mask = 1 << 6;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, mask))
            {
                ItemAction item_script = hit.transform.GetComponent<ItemAction>();
                inventory_manager.AddItem(item_script.item);
                Destroy(hit.transform.gameObject);
            }
        }
    }
}
