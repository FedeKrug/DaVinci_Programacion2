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

	public class AdditiveSceneLoader : MonoBehaviour
	{
		//#region Singleton
		//public static AdditiveSceneLoader instance;

		//private void Awake()
		//{
		//	if (instance == null)
		//	{
		//		instance = this;

		//	}
		//	else
		//	{
		//		Destroy(gameObject);
		//	}
		//}
		//#endregion

		[Header("Scenes")]
		[SerializeField] private string _sceneToLoad;
		[SerializeField] private string _sceneToUnload;

		[Header("Components")]
		[SerializeField] private Animation _doorAnimation;

		private bool _isSceneLoaded;

		private void OnTriggerEnter(Collider other)
		{
			if (_isSceneLoaded) return;
			AsyncOperation additiveScene = SceneManager.LoadSceneAsync(_sceneToLoad, LoadSceneMode.Additive);
			additiveScene.completed += OpenDoor;
			_isSceneLoaded = true;
			gameObject.SetActive(false);

		}

		private void OpenDoor(AsyncOperation asyncOp)
		{
			_doorAnimation.Play();
		}

	}
}
