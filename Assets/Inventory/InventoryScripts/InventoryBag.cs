using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New InventoryBag", menuName = "Inventory/New IventoryBag")]
public class InventoryBag : ScriptableObject
{
   /// <summary>
   /// 玩家背包，因为储存多个物品，所以是一个集合
   /// </summary>
   public List<Item> bagList=new List<Item>();
}
//基于这样的情况我们还可以进行添加商店背包等等.......