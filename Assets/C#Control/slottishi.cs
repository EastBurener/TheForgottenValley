using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slottishi : MonoBehaviour
{
	public GameObject tooltipPanel; // 指向提示框的UI元素
	public float interactionRadius = 2f; // 玩家与门交互的距离

	private bool isPlayerNear = false;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player")) // 确保只有玩家靠近时才显示提示框
		{
			tooltipPanel.SetActive(true); // 显示提示框
		}
	}

	void Update()
	{
		// 检测玩家是否在门的交互范围内
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, interactionRadius);
		isPlayerNear = false;
		foreach (var hitCollider in hitColliders)
		{
			if (hitCollider.CompareTag("Player")) // 假设玩家有一个"Player"标签
			{
				isPlayerNear = true;
				break;
			}
		}
		if (isPlayerNear)
		{
			tooltipPanel.SetActive(true);
		}
	}
		private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player")) // 确保只有玩家离开时才隐藏提示框
		{
			tooltipPanel.SetActive(false); // 隐藏提示框
		}
	}
}
