using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
	public float interactionRadius = 2f; // 玩家与门交互的距离
	public GameObject passwordLockUI; // 密码锁界面的游戏对象

	private bool isPlayerNear = false;

	void Start()
	{
		// 初始化时禁用密码锁界面
		passwordLockUI.SetActive(false);
	}

	void Update()
	{
		// 检测玩家是否在门的交互范围内
		Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, interactionRadius);
		isPlayerNear = false;
		foreach (var hitCollider in hitColliders)
		{
			if (hitCollider.CompareTag("Player")) // 假设玩家有一个"Player"标签
			{
				isPlayerNear = true;
				break;
			}
		}

		// 如果玩家靠近门并且按下了F键
		if (isPlayerNear && Input.GetKeyDown(KeyCode.F))
		{
			// 显示密码锁界面
			passwordLockUI.SetActive(true);
		}
	}
}
