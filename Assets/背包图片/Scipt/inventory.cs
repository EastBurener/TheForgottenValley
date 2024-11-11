using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Inventory",menuName ="Inventory/New Inventory")]
public class inventory : ScriptableObject
{
   public List<item> ItemList = new List<item>();
}
