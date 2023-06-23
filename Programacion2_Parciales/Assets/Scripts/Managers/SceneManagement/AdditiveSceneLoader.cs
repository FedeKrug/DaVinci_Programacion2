using UnityEngine.SceneManagement;
using UnityEngine;

namespace Game.Managers
{
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
			if (_sceneToUnload != null)
			{
				additiveScene = SceneManager.UnloadSceneAsync(_sceneToUnload);
			}

			gameObject.SetActive(false);
		}

		private void OpenDoor(AsyncOperation asyncOp)
		{
			if (_doorAnimation != null)
			{
				_doorAnimation.Play();

			}
		}

	}
}
