using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using JetBrains.Annotations;

public class ToolTipAction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private GameObject player_object;
    private PlayerScript player_script;
    private InventoryManager inventory_manager;
    private Transform item_holder;
    private GameObject tooltip;
    private TextMeshProUGUI tooltip_name;
    private TextMeshProUGUI tooltip_desc;
    private Image tooltip_image;
    public int list_index;
    private float drop_distance;

    private void Awake()
    {
        player_object = GameObject.Find("Player");
        player_script = player_object.GetComponent<PlayerScript>();
        inventory_manager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
        item_holder = GameObject.Find("ItemHolder").transform;
        tooltip = inventory_manager.list_tooltip;
        tooltip_desc = tooltip.transform.Find("TooltipDesc(List)").GetComponent<TextMeshProUGUI>();
        tooltip_name = tooltip.transform.Find("TooltipName(List)").GetComponent<TextMeshProUGUI>();
        tooltip_image = tooltip.transform.Find("TooltipImage(List)").GetComponent<Image>();
        drop_distance = 1.5f;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.SetActive(true);
        tooltip_name.text = inventory_manager.inventory_list[list_index].item_name;
        tooltip_desc.text = inventory_manager.inventory_list[list_index].item_desc;
        tooltip_image.sprite = inventory_manager.inventory_list[list_index].item_icon;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            tooltip.SetActive(false);

            GameObject dropped_item = Instantiate(inventory_manager.inventory_list[list_index].item_object) as GameObject;
            dropped_item.transform.name = inventory_manager.inventory_list[list_index].item_name;
            dropped_item.transform.position = new Vector3(player_object.transform.forward.x + drop_distance, player_object.transform.position.y * 1.5f, player_object.transform.forward.z + drop_distance);
            dropped_item.transform.SetParent(item_holder, true);

            inventory_manager.RemoveItem(inventory_manager.inventory_list[list_index]);
        }
    }
}
