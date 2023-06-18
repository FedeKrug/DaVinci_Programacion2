using UnityEngine;

namespace Game.Managers
{
	public class CanvasManager : MonoBehaviour
	{
		#region Singleton
		public static CanvasManager instance;

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
	}
}
