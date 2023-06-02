using UnityEngine.SceneManagement;
using UnityEngine;

namespace Game.Managers
{
	public class SceneLoader : MonoBehaviour
	{
		public static SceneLoader instance;
		
		private void Awake()
		{
			if (instance == null)
			{
				instance = this;
			}
			else
			{
				Destroy(gameObject);
			}
		}
		public void ChangeScene(string SceneToChange)
		{
			SceneManager.LoadScene(SceneToChange);
		}

		public void ReloadScene()
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
		public void QuitGame()
		{
			Application.Quit();
			Debug.Log("Game Exit");
		}

	}
}
