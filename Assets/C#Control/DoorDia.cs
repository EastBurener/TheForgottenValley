using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDia : MonoBehaviour
{
	public GameObject dialogBox; // 引用对话框UI元素
	//private bool isPlayerInRange = false; // 玩家是否在触发器区域内

	private void OnTriggerEnter2D(Collider2D other)
	{
		// 检测玩家是否进入触发器区域
		if (other.CompareTag("Player")) // 确保只有玩家可以触发对话框
		{
			ShowDialog(); // 显示对话框
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		// 检测玩家是否离开触发器区域
		if (other.CompareTag("Player"))
		{
			HideDialog(); // 隐藏对话框
		}
	}

	private void Update()
	{
		// 检测玩家是否按下了F键
		if (Input.GetKeyDown(KeyCode.F))
		{
			HideDialog(); // 隐藏对话框
		}
	}

	private void ShowDialog()
	{
		dialogBox.SetActive(true); // 显示对话框
	}

	private void HideDialog()
	{
		dialogBox.SetActive(false); // 隐藏对话框
	}
}
