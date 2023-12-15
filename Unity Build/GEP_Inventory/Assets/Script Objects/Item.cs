using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Test")]
public class Item : ScriptableObject
{
    public string item_name;
    public Sprite item_icon;
}
