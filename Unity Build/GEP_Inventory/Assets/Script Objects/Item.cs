using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Test")]
public class Item : ScriptableObject
{
    public string item_name;
    [Multiline]
    public string item_desc;
    public Sprite item_icon;
    public GameObject item_object;
}
