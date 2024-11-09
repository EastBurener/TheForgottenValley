using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour
{
    public GameObject dialogBox;
    public Text dialogBoxText;
    public string signText;
    private bool isPlayerInSign;
	private bool eKeyPressedOnce = true;
	public Transform characterTransform;  // ָ���ɫ��Transform
	public Vector3 offset = new Vector3(0, 3f, 0);  // ƫ������ȷ���ı��ڽ�ɫ�Ϸ�


	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		dialogBox.transform.position = Camera.main.WorldToScreenPoint(characterTransform.position + offset);

		if (Input.GetKeyDown(KeyCode.E)&& isPlayerInSign)
        {
			if (!eKeyPressedOnce)
			{
				
				dialogBox.SetActive(false);
				eKeyPressedOnce = true;
			}
			else
			{
				dialogBox.SetActive(true);
				if (Input.GetKeyUp(KeyCode.E) && !isPlayerInSign)
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
			isPlayerInSign=true;

		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Player")
			&& other.GetType().ToString() == "UnityEngine.CapsuleCollider2D")
		{
			isPlayerInSign = false;
			dialogBox.SetActive(false);
		}
	}
}
