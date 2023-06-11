
using UnityEngine;

namespace Game.Managers
{
	public class GameManager : MonoBehaviour
	{
		public static GameManager instance;


		#region Singleton
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

		public void BlockCursor()
		{
			Cursor.lockState = CursorLockMode.Locked;
		}
		public void HideCursor()
		{
			Cursor.visible = false;
		}
		public void ShowCursor()
		{
			Cursor.visible = true;
		}
		public void FreeCursor()
		{
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
