using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slottishi : MonoBehaviour
{
	public GameObject tooltipPanel; // ָ����ʾ���UIԪ��

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player")) // ȷ��ֻ����ҿ���ʱ����ʾ��ʾ��
		{
			tooltipPanel.SetActive(true); // ��ʾ��ʾ��
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player")) // ȷ��ֻ������뿪ʱ��������ʾ��
		{
			tooltipPanel.SetActive(false); // ������ʾ��
		}
	}
}
