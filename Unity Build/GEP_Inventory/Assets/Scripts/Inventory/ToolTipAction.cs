using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ToolTipAction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private InventoryManager inventory_manager;
    private GameObject tooltip;
    private TextMeshProUGUI tooltip_name;
    private TextMeshProUGUI tooltip_desc;
    private Image tooltip_image;

    public int list_index;

    private void Awake()
    {
        inventory_manager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
        tooltip = inventory_manager.list_tooltip;
        tooltip_desc = tooltip.transform.Find("TooltipDesc(List)").GetComponent<TextMeshProUGUI>();
        tooltip_name = tooltip.transform.Find("TooltipName(List)").GetComponent<TextMeshProUGUI>();
        tooltip_image = tooltip.transform.Find("TooltipImage(List)").GetComponent<Image>();
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
}
