using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnWorld : MonoBehaviour
{
	public item thisItem;
	public inventory playerInventory;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			// 当玩家进入拾取范围时，可以开始检测按键
			canPickUp = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			// 当玩家离开拾取范围时，停止检测按键
			canPickUp = false;
		}
	}

	private bool canPickUp = false;

	private void Update()
	{
		// 检测玩家是否在拾取范围内并且按下了F键
		if (canPickUp && Input.GetKeyDown(KeyCode.F))
		{
			AddNewItem();
			Destroy(gameObject);
		}
	}

	public void AddNewItem()
	{
		if (playerInventory != null && playerInventory.ItemList != null)
		{
			if (!playerInventory.ItemList.Contains(thisItem))
			{
				playerInventory.ItemList.Add(thisItem);
				InventoryManager.CreatNewItem(thisItem);
			}
		}
		else
		{
			Debug.LogError("ItemOnWorld: playerInventory or ItemList is null.");
		}
	}
}
