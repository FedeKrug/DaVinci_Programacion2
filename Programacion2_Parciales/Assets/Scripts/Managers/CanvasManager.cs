using UnityEngine;
using UnityEngine.UI;


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
		[Header("Screens")]
		[SerializeField] private Canvas[] _menuCanvas;

		[Header("Sliders")]
		[SerializeField, Range(0.0001f, 1f)] private float _initMusicVol = 0.0001f;
		[SerializeField] private Slider[] _volumeSliders;

		private SceneLoader _sceneLoader;

		private void Start()
		{
			_sceneLoader = GetComponent<SceneLoader>();

			if (_menuCanvas.Length==0)
			{
				_menuCanvas = GetComponentsInChildren<Canvas>();
			}
			if (_volumeSliders.Length ==0)
			{
				_volumeSliders = GetComponentsInChildren<Slider>();
			}
			AudioManager.instance.SetMasterVolume(_initMusicVol);
			_volumeSliders[0].value = _initMusicVol;

			for (int i =0; i<_menuCanvas.Length; i++)
			{
				if (i!=0)
				{
					_menuCanvas[i].enabled = false;
				}
			}
		}

	}
}
