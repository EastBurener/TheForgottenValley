using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keypad : MonoBehaviour
{
    [SerializeField] private Text Ans;
	[SerializeField] private GameObject door; // 引用到门的游戏对象
											  // [SerializeField] private Animator Door;
	[SerializeField] private GameObject doorToOpen;

	private string Answer = "96";

    public void Number(int number)
    {
        Ans.text += number.ToString();
    }

    public void Execute()
    {
        if(Ans.text == Answer)
        {
            Ans.text = "Correct";
          //  Door.SetBool("Open", true);
           // StartCoroutine("StopDoor");
			Destroy(door);
			doorToOpen.SetActive(true);
		}
        else
        {
            Ans.text = "";
        }
    }

    
}
