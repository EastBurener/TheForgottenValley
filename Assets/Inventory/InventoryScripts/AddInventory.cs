using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//该脚本绑定到游戏场景中的物品下
public class AddInventory : MonoBehaviour
{
    public Item thisItem;//给物品注册该物品是哪一类的物品
    public InventoryBag thisBag;//玩家背包

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            AddItem();
            Destroy(gameObject);
        }
    }

    void AddItem()
    {
        if (!thisBag.bagList.Contains(thisItem))
        {
            //thisBag.bagList.Add(thisItem);
            //遍历背包，如果为null的话就设置成该物品，因为我们直接给装备栏添加了18个物品，只是初始化都是null
            for (int i = 0; i < thisBag.bagList.Count; i++)
            {
                if (thisBag.bagList[i] == null)
                {
                    thisBag.bagList[i] = thisItem;
                    break;
                }
            }
        }
        else
        {
            thisItem.itemHeld += 1;//如果存在该物品，就将数量+1；
        }
        InventoryMannage.RestItem();//更新背包的数据
    }
}
