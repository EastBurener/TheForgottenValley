// GameController.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public static GameController Instance { get; private set; }

	public int victoryPoints = 0;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void IncrementVictoryPoints()
	{
		victoryPoints++;
		Debug.Log("Victory Points: " + victoryPoints);

		if (victoryPoints == 5)//�����ʼ���ţ�������4�����ϼ�1��ʤ��
		{
			LoadScene("Third");
		}
	}

	public void delectpoint()
	{
		victoryPoints = 0;
		Debug.Log("Victory Points: " + victoryPoints);
		LoadScene("Second");
	}

	private void LoadScene(string sceneNamse)
	{
		SceneManager.LoadScene(sceneNamse);
	}

	public int vpoint()
	{
		return victoryPoints;
	}
}
