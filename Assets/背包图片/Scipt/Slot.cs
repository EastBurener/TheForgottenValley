using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public item slotItem;
    public Image slotImage;

    public void ItemOnClicked() 
    {
        InventoryManager.UpdateItemInfo(slotItem.itemInfo);
    }
}
