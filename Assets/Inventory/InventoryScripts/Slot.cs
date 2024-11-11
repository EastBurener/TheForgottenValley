using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    /// <summary>
    /// 装备栏的序号
    /// </summary>
    public int slotId;
    public Item slotItem;
    public Image slotIamge;//物品的图片
    public Text Num;//数量Text
    public string slotInfo;//物品信息
    public GameObject itemInSlot;//拖动的Item


    public void SlotOnClick()//注册物品点击事件
    {
        InventoryMannage.UpItemInfomation(slotInfo);//更新背包的描述信息栏的信息
    }

    //物品的信息初始化设置
    public void SetupSlot(Item item)
    {
        //这里就是没有物品的话就禁用
        if (item == null)
        {
            itemInSlot.SetActive(false);
            return;
        }

        slotIamge.sprite = item.ItemSprite;
        Num.text = item.itemHeld.ToString();
        slotInfo = item.itemInfo;
        
    }
}
