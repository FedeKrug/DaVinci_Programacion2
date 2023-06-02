using System;
using UnityEngine;
using Game.Managers;
namespace Game.Cameras
{
	[DefaultExecutionOrder(-5)]
	public class CameraManager : MonoBehaviour
	{
		#region Singleton & Awake
		public static CameraManager insance;
		private void Awake()
		{
			if (insance == null)
			{
				insance = this;
			}
			else
			{
				Destroy(gameObject);
			}

			_restrictedCameraType = _actualCamera;
		}

		#endregion

		//public Func<TypesOfCamera> cameraChangerFunc; 
		[SerializeField] private InteractableTrigger _playerInteractor;
		public TypesOfCamera _restrictedCameraType { get; private set; }
		[SerializeField] private TypesOfCamera _actualCamera;
		[SerializeField] private CameraController _cameraControll;


		public TypesOfCamera ActualCamera
		{
			get => _actualCamera;
			set => _actualCamera = value;
		}

		private void OnEnable()
		{
			EventManager.instance.cameraChangeEvent.AddListener(CameraUpdaterHandler);
		}

		private void OnDisable()
		{
			EventManager.instance.cameraChangeEvent.RemoveListener(CameraUpdaterHandler);

		}


		public void CameraUpdaterHandler(TypesOfCamera newCamera)
		{
			_cameraControll.cameraType = newCamera;

		}
	}


}
