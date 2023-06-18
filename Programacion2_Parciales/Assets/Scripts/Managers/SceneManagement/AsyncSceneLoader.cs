using UnityEngine;

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

		[SerializeField] private string _sceneToLoad;
		[SerializeField] private string _sceneToUnload;

		public void ChangeSceneAsync(string sceneToLoad)
		{

		}



	}
}
