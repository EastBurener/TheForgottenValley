using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDia : MonoBehaviour
{
	public GameObject dialogBox; // ���öԻ���UIԪ��
	//private bool isPlayerInRange = false; // ����Ƿ��ڴ�����������

	private void OnTriggerEnter2D(Collider2D other)
	{
		// �������Ƿ���봥��������
		if (other.CompareTag("Player")) // ȷ��ֻ����ҿ��Դ����Ի���
		{
			ShowDialog(); // ��ʾ�Ի���
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		// �������Ƿ��뿪����������
		if (other.CompareTag("Player"))
		{
			HideDialog(); // ���ضԻ���
		}
	}

	private void Update()
	{
		// �������Ƿ�����F��
		if (Input.GetKeyDown(KeyCode.F))
		{
			HideDialog(); // ���ضԻ���
		}
	}

	private void ShowDialog()
	{
		dialogBox.SetActive(true); // ��ʾ�Ի���
	}

	private void HideDialog()
	{
		dialogBox.SetActive(false); // ���ضԻ���
	}
}
