using UnityEngine.SceneManagement;
using UnityEngine;



namespace Game.Managers
{
	public class AdditiveSceneLoader : MonoBehaviour
	{
		[Header("Scenes")]
		[SerializeField] private string _sceneToLoad;
		[SerializeField] private string _sceneToUnload;

		[Header("CompletationCondition")]
		public BoxCollider boxCollider;
		//public bool canGoFurther;


		[Header("Animations")]
		[SerializeField] private Animation _doorAnimation;
		[SerializeField] private AnimationClip _OpenDoorAnimation, _closeDoorAnimation;

		[SerializeField] private bool _isSceneLoaded;



		private void OnTriggerEnter(Collider other)
		{
			if (_isSceneLoaded) return;


			if (other.CompareTag("Player"))
			{
				AsyncOperation additiveScene = SceneManager.LoadSceneAsync(_sceneToLoad, LoadSceneMode.Additive);
				if (_sceneToLoad != "")
				{
					Debug.Log("Scene is loading");
					additiveScene.completed += OpenDoor;
					_isSceneLoaded = true;
				}

				if (_sceneToUnload != "")
				{
					Debug.Log("Scene is unloading");
					additiveScene = SceneManager.UnloadSceneAsync(_sceneToUnload);
					additiveScene.completed += CloseDoor;
				}
			}

			gameObject.SetActive(false);
		}

		private void OpenDoor(AsyncOperation asyncOp)
		{
			_doorAnimation.clip = _OpenDoorAnimation;
			_doorAnimation.Play();
		}
		private void CloseDoor(AsyncOperation asyncOp)
		{
			_doorAnimation.clip = _closeDoorAnimation;
			_doorAnimation.Play();
		}

	}
}


