using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackSign : MonoBehaviour
{
	public GameObject dialogBox, dialogBox2;
	public Text dialogBoxText, dialogBoxText2;
	public string signText, signText2;
	private bool isPlayerInSign;
	private bool eKeyPressedOnce = true;
	private bool eKeyPressedOnce2 = false;
	public Transform characterTransform;  // ָ���ɫ��Transform
	public Vector3 offset = new Vector3(0, 3f, 0);  // ƫ������ȷ���ı��ڽ�ɫ�Ϸ�

	private float displayTime = 3f; // �Ի�����ʾ��ʱ�䣨�룩
	private float timer,timer2; // ��ʱ��


	// Start is called before the first frame update
	void Start()
	{
		timer = 0f;
		timer2 = 0f;
		dialogBox2.SetActive(false); // ȷ���Ի���ʼʱ�ǿɼ���
	}

	// Update is called once per frame
	void Update()
	{
		dialogBox.transform.position = Camera.main.WorldToScreenPoint(characterTransform.position + offset);

		if (eKeyPressedOnce2) {
			timer += Time.deltaTime; // ���¼�ʱ��
									 // �����ʱ���������趨����ʾʱ��
			if (timer >= displayTime)
			{
				dialogBox2.SetActive(false); // ���ضԻ���
				timer = 0f; // ���ü�ʱ��
			}
			timer2 += Time.deltaTime; // ���¼�ʱ��
									 // �����ʱ���������趨����ʾʱ��
			if (timer2 >= displayTime)
			{
				dialogBox.SetActive(false); // ���ضԻ���
				timer2 = 0f; // ���ü�ʱ��
			}
		}
		if (isPlayerInSign)
		//if ( isPlayerInSign)
		{
			if (!eKeyPressedOnce)
			{

				dialogBox.SetActive(false);
				eKeyPressedOnce = true;
			}
			else
			{
				dialogBox.SetActive(true);
				if (!isPlayerInSign)
					dialogBox.SetActive(false);
				eKeyPressedOnce = false;
			}
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
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player")
			&& other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
		{
			isPlayerInSign = false;
			dialogBox.SetActive(false);

			dialogBox2.SetActive(true);
			eKeyPressedOnce2 = true;



		}
	}
}
