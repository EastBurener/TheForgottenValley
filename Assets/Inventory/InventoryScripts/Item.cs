using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")]
public class Item : ScriptableObject
{
    public string itemName;//物品名字
    public Sprite ItemSprite;//物品的照片
    public int itemHeld=1;//物品的数量，默认是一个，因为拾取第一个后直接为1，再拾取就直接+1即可
    [TextArea]//使text可以富文本进行多行书写
    public string itemInfo;//物品的介绍描述

}
//该脚本是一个物品的基础脚本
