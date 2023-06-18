using UnityEngine.SceneManagement;
using UnityEngine;

namespace Game.Managers
{
	public class SceneLoader : MonoBehaviour
	{
		#region Singleton
		public static SceneLoader instance;
		
		private void Awake()
		{
			if (instance == null)
			{
				instance = this;
				DontDestroyOnLoad(gameObject);
			}
			else
			{
				Destroy(gameObject);
			}
		}
		#endregion
		public void ChangeScene(string SceneToChange)
		{
			SceneManager.LoadScene(SceneToChange);
		}

		public void AdditiveScene()
		{

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
