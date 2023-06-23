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
		[SerializeField] private Slider[] _volumeSliders;
		[SerializeField] private AsyncSceneLoader _asynSceneLoader;


		private void Start()
		{
			if (_menuCanvas.Length == 0)
			{
				_menuCanvas = GetComponentsInChildren<Canvas>();
			}
			if (_volumeSliders.Length == 0)
			{
				_volumeSliders = GetComponentsInChildren<Slider>();
			}
			AudioManager.instance.SetMasterVolume(_initMusicVol);
			_volumeSliders[0].value = _initMusicVol;

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
		public void SetMouseSensibility(FloatSO mouseSens)
		{
			mouseSens.value = _volumeSliders[3].value;
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
	}
}
