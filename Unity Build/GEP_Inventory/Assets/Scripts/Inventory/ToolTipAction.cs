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
    private Image tooltip_image;
    private TextMeshProUGUI tooltip_text;
    public int list_index;

    private void Awake()
    {
        inventory_manager = GameObject.Find("InventoryManager").GetComponent<InventoryManager>();
        tooltip = inventory_manager.list_tooltip;
        tooltip_image = tooltip.transform.Find("TooltipImage(List)").GetComponent<Image>();
        tooltip_text = tooltip.transform.Find("TooltipName(List)").GetComponent<TextMeshProUGUI>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltip.SetActive(true);
        tooltip_image.sprite = inventory_manager.inventory_list[list_index].item_icon;
        tooltip_text.text = inventory_manager.inventory_list[list_index].item_name;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.SetActive(false);
    }
}
