using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // �����Ҫ������������

public class BackpackMenu : MonoBehaviour
{
	public Button continueButton;
	public Button exitButton;

	void Start()
	{
		// �󶨰�ť����¼�
		continueButton.onClick.AddListener(ContinueGame);
		exitButton.onClick.AddListener(ExitGame);
	}

	void ContinueGame()
	{
		// �����д������Ϸ���߼���������ñ�������
		Debug.Log("������Ϸ");
		// ����ʹ��Time.timeScale = 1; �ָ���Ϸʱ��
		gameObject.SetActive(false); // ���豳��������gameObject
	}

	void ExitGame()
	{
		// �����д������Ϸ���߼�
		Debug.Log("������Ϸ");
		// �������˳�Ӧ�õ����棬���߷������˵�
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
	}
}
