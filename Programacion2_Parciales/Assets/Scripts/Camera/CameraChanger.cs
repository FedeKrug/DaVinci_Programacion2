using Game.Managers;
using UnityEngine;
using System.Collections;
namespace Game.Cameras
{
	
	public class CameraChanger : MonoBehaviour
	{
		public TypesOfCamera _newCamera;
		private TypesOfCamera _oldCamera;
		[SerializeField] private bool _changed;
		private void Start()
		{
			_oldCamera = CameraManager.insance._restrictedCameraType;
		}
		private void OnTriggerEnter(Collider other)
		{
			if (other.CompareTag("Player"))
			{
				ChangeCamera();
			}
		}
		

		public void ChangeCamera()
		{
			EventManager.instance.cameraChangeEvent.Invoke(_newCamera);
		}
	}


}
