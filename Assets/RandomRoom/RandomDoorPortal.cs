// RandomDoorPortal.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomDoorPortal : MonoBehaviour
{
	public string[] sceneNames;
	public bool isExitDoor = true;


	private void OnTriggerEnter2D(Collider2D other)
	{
		//if (Input.GetKeyDown(KeyCode.F))
		//{


			if (other.CompareTag("Player"))//&& Input.GetKeyDown(KeyCode.E))
			{
				if (isExitDoor)
				{
					GameController.Instance.IncrementVictoryPoints();
					int v_point = GameController.Instance.vpoint();
					//Debug.Log(a);
					if (v_point >= 5)
					{
						SceneManager.LoadScene("Third");
					}
					else
					{
						string randomSceneName = GetRandomSceneNameExcludingJieshu();
						SceneManager.LoadScene(randomSceneName);
					}
				}
				else
				{
					//if ( Input.GetKeyDown(KeyCode.E))
					//string randomSceneName = GetRandomSceneNameExcludingJieshu();
					GameController.Instance.delectpoint();//清空分数,回到开始

					//GameController.Instance.IncrementVictoryPoints();

				}
			}
		//}
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
		} while (sceneName == "Third");

		return sceneName;
	}
}
