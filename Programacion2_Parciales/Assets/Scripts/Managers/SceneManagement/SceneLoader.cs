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
				
			}
			else
			{
				Destroy(gameObject);
			}
		}
		#endregion
		[SerializeField] private CanvasManager _canvasRef;
		public void ChangeScene(string SceneToChange)
		{
			if (_canvasRef)
			{
				Destroy(_canvasRef.gameObject);
			}
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
