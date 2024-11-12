using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class 过场 : MonoBehaviour
{
	public GameObject dialogBox;
	public Text dialogBoxText;
	public string signText;
	private bool isPlayerInSign;
	//private bool eKeyPressedOnce = true;

	private float displayTime = 4f; // 对话框显示的时间（秒）
	private float timer; // 计时器
						 // Start is called before the first frame update
	void Start()
	{
		timer = 0f;
		dialogBox.SetActive(false); // 确保对话框开始时是可见的
	}

	// Update is called once per frame
	void Update()
	{
		if (isPlayerInSign)
		//if ( isPlayerInSign)
		{
			timer += Time.deltaTime; // 更新计时器
			dialogBox.SetActive(true);
		}
		if (timer >= displayTime)
		{
			dialogBox.SetActive(false);
			Destroy(gameObject);
			//timer = 0f; // 重置计时器
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
