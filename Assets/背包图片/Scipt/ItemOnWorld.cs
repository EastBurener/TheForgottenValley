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
			// ����ҽ���ʰȡ��Χʱ�����Կ�ʼ��ⰴ��
			canPickUp = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			// ������뿪ʰȡ��Χʱ��ֹͣ��ⰴ��
			canPickUp = false;
		}
	}

	private bool canPickUp = false;

	private void Update()
	{
		// �������Ƿ���ʰȡ��Χ�ڲ��Ұ�����F��
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
