using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Black1 : MonoBehaviour
{
	public GameObject dialogBox;
	public Text dialogBoxText;
	public string signText;
	private bool isPlayerInSign;
	//private bool eKeyPressedOnce = true;

	private float displayTime = 2f; // �Ի�����ʾ��ʱ�䣨�룩
	private float timer; // ��ʱ��
								 // Start is called before the first frame update
	void Start()
	{
		timer = 0f;
		dialogBox.SetActive(false); // ȷ���Ի���ʼʱ�ǿɼ���
	}

	// Update is called once per frame
	void Update()
	{
		if (isPlayerInSign)
		//if ( isPlayerInSign)
		{
			timer += Time.deltaTime; // ���¼�ʱ��
			dialogBox.SetActive(true);
		}
		if (timer >= displayTime)
		{
			dialogBox.SetActive(false);
			//timer = 0f; // ���ü�ʱ��
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player")
			&& other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
		{
			isPlayerInSign = true;

		}
	}
}
