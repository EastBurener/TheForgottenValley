using UnityEngine;

public class DoorOpener : MonoBehaviour
{
	public GameObject panel; // ����������
	public GameObject door;  // �Ŷ���
	public string correctPassword = "96"; // ��ȷ����

	private bool isPlayerNear = false; // ����Ƿ񿿽���
	private bool isPanelActive = false; // �����������Ƿ񼤻�

	void Update()
	{
		// �������Ƿ񿿽���
		if (isPlayerNear && Input.GetKeyDown(KeyCode.F))
		{
			// �����ر�����������
			isPanelActive = !isPanelActive;
			panel.SetActive(isPanelActive);
		}

		// ������������漤�����������������
		if (isPanelActive && Input.GetKeyDown(KeyCode.Return))
		{
			// ����������һ����������ȡ������������
			string inputPassword = GetPlayerInputPassword();

			// ��������Ƿ���ȷ
			if (inputPassword == correctPassword)
			{
				// ������
				Destroy(door);
				// ����ѡ��ر�����������
				panel.SetActive(false);
			}
		}
	}

	// ���������Ҫ�����ʵ�������ʵ�֣����ڻ�ȡ������������
	private string GetPlayerInputPassword()
	{
		// ����Ӧ���ǻ�ȡ�������������߼�
		// ���磬�������һ���������ҿ�����������������
		// ����ֻ�Ƿ���һ��ʾ������
		return "96"; // Ӧ�������ʵ�����������
	}

	// ����ҽ��봥������ʱ����
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			isPlayerNear = true;
		}
	}

	// ������뿪��������ʱ����
	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			isPlayerNear = false;
			// ȷ��������뿪ʱ�ر�����������
			panel.SetActive(false);
		}
	}
}
