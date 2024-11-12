using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slottishi : MonoBehaviour
{
	public GameObject tooltipPanel; // ָ����ʾ���UIԪ��
	public float interactionRadius = 2f; // ������Ž����ľ���

	private bool isPlayerNear = false;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player")) // ȷ��ֻ����ҿ���ʱ����ʾ��ʾ��
		{
			tooltipPanel.SetActive(true); // ��ʾ��ʾ��
		}
	}

	void Update()
	{
		// �������Ƿ����ŵĽ�����Χ��
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, interactionRadius);
		isPlayerNear = false;
		foreach (var hitCollider in hitColliders)
		{
			if (hitCollider.CompareTag("Player")) // ���������һ��"Player"��ǩ
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
		if (other.CompareTag("Player")) // ȷ��ֻ������뿪ʱ��������ʾ��
		{
			tooltipPanel.SetActive(false); // ������ʾ��
		}
	}
}
