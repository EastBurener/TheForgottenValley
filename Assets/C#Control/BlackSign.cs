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
	public Transform characterTransform;  // 指向角色的Transform
	public Vector3 offset = new Vector3(0, 3f, 0);  // 偏移量，确保文本在角色上方

	private float displayTime = 3f; // 对话框显示的时间（秒）
	private float timer,timer2; // 计时器


	// Start is called before the first frame update
	void Start()
	{
		timer = 0f;
		timer2 = 0f;
		dialogBox2.SetActive(false); // 确保对话框开始时是可见的
	}

	// Update is called once per frame
	void Update()
	{
		dialogBox.transform.position = Camera.main.WorldToScreenPoint(characterTransform.position + offset);

		if (eKeyPressedOnce2) {
			timer += Time.deltaTime; // 更新计时器
									 // 如果计时器超过了设定的显示时间
			if (timer >= displayTime)
			{
				dialogBox2.SetActive(false); // 隐藏对话框
				timer = 0f; // 重置计时器
			}
			timer2 += Time.deltaTime; // 更新计时器
									 // 如果计时器超过了设定的显示时间
			if (timer2 >= displayTime)
			{
				dialogBox.SetActive(false); // 隐藏对话框
				timer2 = 0f; // 重置计时器
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
