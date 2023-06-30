using UnityEngine;
using UnityEngine.UI;
using Game.SO;

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
			}
			//else
			//{
				//Destroy(gameObject);
			//}
		}
		#endregion
		[Header("Screens")]
		[SerializeField] private Canvas[] _menuCanvas;

		[Header("Sliders")]
		[SerializeField, Range(0.0001f, 1f)] private float _initMusicVol = 0.0001f;
		[SerializeField] private Slider[] _sliders;
		[SerializeField] private AsyncSceneLoader _asynSceneLoader;


		private void Start()
		{
			if (_menuCanvas.Length == 0)
			{
				_menuCanvas = GetComponentsInChildren<Canvas>();
			}
			if (_sliders.Length == 0)
			{
				_sliders = GetComponentsInChildren<Slider>();
			}
			AudioManager.instance.SetMasterVolume(_initMusicVol);
			_sliders[0].value = _initMusicVol;

			for (int i = 0; i < _menuCanvas.Length; i++)
			{
				if (i != 0)
				{
					_menuCanvas[i].enabled = false;
				}
			}
		}
		public void EnableMenu(int menuToShow)
		{
			if (_asynSceneLoader != null)
			{
				if (_asynSceneLoader.IsAsyncLoading) return;

			}
			for (int i = 0; i < _menuCanvas.Length; i++)
			{
				if (i == menuToShow)
				{
					_menuCanvas[i].enabled = true;
				}
				else if (i != menuToShow && _menuCanvas[i].enabled)
				{
					_menuCanvas[i].enabled = false;
				}
			}
		}
		public void SetMouseSensibility(FloatSO mouseSensibility)
		{
			mouseSensibility.value = _sliders[3].value;
		}

		public void TurnOffMenus()
		{
			for (int i = 0; i < _menuCanvas.Length; i++)
			{
				_menuCanvas[i].enabled = false;
			}
		}

		public void DestroyMenus()
		{
			for (int i = 0; i < _menuCanvas.Length; i++)
			{
				Destroy(_menuCanvas[i].gameObject);
			}
		}

		public void GoalScreen()
		{
			TurnOffMenus();
			_menuCanvas[2].enabled = true; //posicion de goalCanvas = 2
			GameManager.instance.FreeCursor();
			GameManager.instance.ShowCursor();
		}
	}
}
