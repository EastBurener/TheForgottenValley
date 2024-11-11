using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
	public float interactionRadius = 2f; // ������Ž����ľ���
	public GameObject passwordLockUI; // �������������Ϸ����

	private bool isPlayerNear = false;

	void Start()
	{
		// ��ʼ��ʱ��������������
		passwordLockUI.SetActive(false);
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

		// �����ҿ����Ų��Ұ�����F��
		if (isPlayerNear && Input.GetKeyDown(KeyCode.F))
		{
			// ��ʾ����������
			passwordLockUI.SetActive(true);
		}
	}
}
