using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // 如果需要加载其他场景

public class BackpackMenu : MonoBehaviour
{
	public Button continueButton;
	public Button exitButton;

	void Start()
	{
		// 绑定按钮点击事件
		continueButton.onClick.AddListener(ContinueGame);
		exitButton.onClick.AddListener(ExitGame);
	}

	void ContinueGame()
	{
		// 这里编写继续游戏的逻辑，比如禁用背包界面
		Debug.Log("继续游戏");
		// 可以使用Time.timeScale = 1; 恢复游戏时间
		gameObject.SetActive(false); // 假设背包界面是gameObject
	}

	void ExitGame()
	{
		// 这里编写结束游戏的逻辑
		Debug.Log("结束游戏");
		// 可以是退出应用到桌面，或者返回主菜单
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
	}
}
