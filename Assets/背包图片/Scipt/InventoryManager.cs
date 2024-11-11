using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

	public inventory MyBag;
	public GameObject slotGrid;
	public Slot slotPrefab;
	public Text itemInformation;

	private void OnEnable()
	{
		instance.itemInformation.text = "";
	}

	public static void UpdateItemInfo(string itemDescription)
	{
		instance.itemInformation.text = itemDescription;
	}

	private void Awake()
	{
		if(instance != null)
		{
			Destroy(this);
		}
		instance = this;
	}

	public static void CreatNewItem(item item)
	{
		Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
		newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
		newItem.slotItem = item;
		newItem.slotImage.sprite = item.itemImage;
	}
}
