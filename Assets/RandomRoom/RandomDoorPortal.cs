// RandomDoorPortal.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomDoorPortal : MonoBehaviour
{
	public string[] sceneNames;
	public bool isExitDoor = true;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			if (isExitDoor)
			{
				GameController.Instance.IncrementVictoryPoints();
				int a = GameController.Instance.vpoint();
				//Debug.Log(a);
				if (a >= 3)
				{
					SceneManager.LoadScene("jieshu");
				}
				else
				{
					string randomSceneName = GetRandomSceneNameExcludingJieshu();
					SceneManager.LoadScene(randomSceneName);
				}
			}
			else
			{
				//string randomSceneName = GetRandomSceneNameExcludingJieshu();
				GameController.Instance.delectpoint();//清空分数,回到开始
				
				//GameController.Instance.IncrementVictoryPoints();
				
			}
		}
	}

	private string GetRandomSceneNameExcludingJieshu()
	{
		if (sceneNames == null || sceneNames.Length == 0)
		{
			Debug.LogError("Scene names array is empty or not assigned.");
			return string.Empty;
		}

		string sceneName;
		do
		{
			int randomIndex = Random.Range(0, sceneNames.Length);
			sceneName = sceneNames[randomIndex];
		} while (sceneName == "jieshu");

		return sceneName;
	}
}
