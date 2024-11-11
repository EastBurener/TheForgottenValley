using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slottishi : MonoBehaviour
{
	public GameObject tooltipPanel; // 指向提示框的UI元素

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player")) // 确保只有玩家靠近时才显示提示框
		{
			tooltipPanel.SetActive(true); // 显示提示框
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
