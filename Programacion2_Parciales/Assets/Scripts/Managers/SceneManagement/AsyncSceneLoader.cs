using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

namespace Game.Managers
{
	public class AsyncSceneLoader : MonoBehaviour
	{
		#region Singleton
		public static AsyncSceneLoader instance;
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

		[SerializeField] private KeyCode _loadSceneButton = KeyCode.Space;

		[Header("UI Elements")]
		[SerializeField] private Image _loadBarParent;
		[SerializeField] private Image _loadBar;
		[SerializeField] private Color _loadProgressColor = Color.red;
		[SerializeField] private Color _loadDoneColor = Color.green;
		

		private bool _isAsyncLoading;
		public bool IsAsyncLoading { get { return _isAsyncLoading; } }

		private void Start()
		{
			_loadBar.fillAmount = 0;
			_loadBar.enabled = false;
		}



		public void LoadSceneAsync(string sceneToLoad)
		{
			StartCoroutine(LoadAsync(sceneToLoad));
		}
		private IEnumerator LoadAsync(string sceneToLoad)
		{
			_isAsyncLoading = true;
			AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneToLoad);
			asyncLoad.allowSceneActivation = false;
			_loadBarParent.enabled = true;
			//_loadBar.color = _loadProgressColor;
			while (asyncLoad.progress <0.9f)
			{
				_loadBar.fillAmount = asyncLoad.progress / 0.9f;
				_loadBar.color = _loadProgressColor;
				yield return null;
			}
			_loadBar.fillAmount = 1;
			_loadBar.color = _loadDoneColor;

			while (!Input.GetKey(_loadSceneButton))
			{
				yield return null;
			}
			asyncLoad.allowSceneActivation = true;
			GetComponent<CanvasManager>().DestroyMenus();
		}


	}
}
