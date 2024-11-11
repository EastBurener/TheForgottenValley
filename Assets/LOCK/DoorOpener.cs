using UnityEngine;

public class DoorOpener : MonoBehaviour
{
	public GameObject panel; // 密码锁界面
	public GameObject door;  // 门对象
	public string correctPassword = "96"; // 正确密码

	private bool isPlayerNear = false; // 玩家是否靠近门
	private bool isPanelActive = false; // 密码锁界面是否激活

	void Update()
	{
		// 检测玩家是否靠近门
		if (isPlayerNear && Input.GetKeyDown(KeyCode.F))
		{
			// 激活或关闭密码锁界面
			isPanelActive = !isPanelActive;
			panel.SetActive(isPanelActive);
		}

		// 如果密码锁界面激活且玩家输入了密码
		if (isPanelActive && Input.GetKeyDown(KeyCode.Return))
		{
			// 假设这里有一个函数来获取玩家输入的密码
			string inputPassword = GetPlayerInputPassword();

			// 检查密码是否正确
			if (inputPassword == correctPassword)
			{
				// 销毁门
				Destroy(door);
				// 可以选择关闭密码锁界面
				panel.SetActive(false);
			}
		}
	}

	// 这个函数需要你根据实际情况来实现，用于获取玩家输入的密码
	private string GetPlayerInputPassword()
	{
		// 这里应该是获取玩家输入密码的逻辑
		// 例如，你可能有一个输入框，玩家可以在那里输入密码
		// 这里只是返回一个示例密码
		return "96"; // 应该是玩家实际输入的密码
	}

	// 当玩家进入触发区域时调用
	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			isPlayerNear = true;
		}
	}

	// 当玩家离开触发区域时调用
	void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			isPlayerNear = false;
			// 确保在玩家离开时关闭密码锁界面
			panel.SetActive(false);
		}
	}
}
