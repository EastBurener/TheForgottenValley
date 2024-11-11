using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject inventoryMenu;

	private void Start()
	{
		inventoryMenu.gameObject.SetActive(false);
	}//不让游戏开始时就看到背包界面  

	private void Update()
	{
		InventoryControl();
	}

	private void InventoryControl()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			//如果游戏暂停，我们按下Ese游戏继续
			if(GameManager.instance.isPaused) {Resume() ; }
			else
			{
				Pause();//或者反之
			}
			
		}
	}

	private void Resume()
	{
		inventoryMenu.gameObject.SetActive (false);
		Time.timeScale = 1.0f;	//真实时间流逝
		GameManager.instance.isPaused = false;
	}

	private void Pause()
	{
		inventoryMenu.gameObject.SetActive(true);
		Time.timeScale = 0.0f;//时停
		GameManager.instance.isPaused = true;
	}
}
