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
	}//������Ϸ��ʼʱ�Ϳ�����������  

	private void Update()
	{
		InventoryControl();
	}

	private void InventoryControl()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			//�����Ϸ��ͣ�����ǰ���Ese��Ϸ����
			if(GameManager.instance.isPaused) {Resume() ; }
			else
			{
				Pause();//���߷�֮
			}
			
		}
	}

	private void Resume()
	{
		inventoryMenu.gameObject.SetActive (false);
		Time.timeScale = 1.0f;	//��ʵʱ������
		GameManager.instance.isPaused = false;
	}

	private void Pause()
	{
		inventoryMenu.gameObject.SetActive(true);
		Time.timeScale = 0.0f;//ʱͣ
		GameManager.instance.isPaused = true;
	}
}
