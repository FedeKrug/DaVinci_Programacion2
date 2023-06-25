using UnityEngine.SceneManagement;
using UnityEngine;



namespace Game.Managers
{
	public class AdditiveSceneLoader : MonoBehaviour
	{
		

		[Header("Scenes")]
		[SerializeField] private string _sceneToLoad;
		[SerializeField] private string _sceneToUnload;

		[Header("Components")]
		[SerializeField] private Animation _doorAnimation;

		[SerializeField] private bool _isSceneLoaded;

		private void OnTriggerEnter(Collider other)
		{
			if (_isSceneLoaded)
			{
				Debug.Log("Scene is already loaded");
				return;
			}

			if (other.CompareTag("Player"))
			{
				Debug.Log("Scene is loading");
				AsyncOperation additiveScene = SceneManager.LoadSceneAsync(_sceneToLoad, LoadSceneMode.Additive);
				additiveScene.completed += OpenDoor;
				_isSceneLoaded = true;

				if (_sceneToUnload != "")
				{
					additiveScene = SceneManager.UnloadSceneAsync(_sceneToUnload);
				}
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

	//public class AdditiveSceneLoader : MonoBehaviour
	//{
	//	[Header("Additive Scene Manager")]
	//	[SerializeField] private string _sceneToLoad;

	//	[Header("Components")]
	//	[SerializeField] private Animation _doorAnimator;

	//	private bool _isSceneLoaded;

	//	private void OnTriggerEnter(Collider other)
	//	{
			

	//		if (_isSceneLoaded) return;
	//		Debug.Log("Scene is loading");
	//		AsyncOperation additiveLoad = SceneManager.LoadSceneAsync(_sceneToLoad, LoadSceneMode.Additive);
	//		additiveLoad.completed += OpenDoor;
	//		_isSceneLoaded = true;
	//		Debug.Log("Scene is loaded");

	//		gameObject.SetActive(false);
	//	}

	//	private void OpenDoor(AsyncOperation asyncOp)
	//	{
	//		_doorAnimator.Play();
	//	}
	//}
//}
