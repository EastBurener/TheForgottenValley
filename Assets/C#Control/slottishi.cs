using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class slottishi : MonoBehaviour
{
	public GameObject tooltipPanel; // ָ����ʾ���UIԪ��
	public float interactionRadius = 2f; // ������Ž����ľ���

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

	void Update()
	{
		// �������Ƿ����ŵĽ�����Χ��
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, interactionRadius);
		bool playerInRange = false;
		foreach (var hitCollider in hitColliders)
		{
			if (hitCollider.CompareTag("Player")) // ���������һ��"Player"��ǩ
			{
				playerInRange = true;
				break;
			}
		}
		// �����Ҳ��ڷ�Χ�ڣ�ȷ����ʾ�������ص�
		if (!playerInRange)
		{
			tooltipPanel.SetActive(false);
		}
	}
}
